using DevFast.Net.Extensions.SystemTypes;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace DevFast.Net.Text.Json.Utf8
{
    /// <summary>
    /// Class implementing <see cref="IAsyncJsonArrayPartReader"/> for standard Utf-8 JSON data encoding
    /// based on https://datatracker.ietf.org/doc/html/rfc7159 (grammar shown at https://www.json.org/json-en.html).
    /// <para>
    /// This implementation support both single line comments (starting with '//' and ending in either Carriage return '\r'
    /// or newline '\n') and multiline comments (starting with '/*' and ending with '*/').
    /// </para>
    /// </summary>
    public sealed class AsyncUtf8JsonArrayPartReader : IAsyncJsonArrayPartReader
    {
        private readonly ReaderBuffer _buffer;

        internal AsyncUtf8JsonArrayPartReader(Stream stream, byte[] buffer, int begin, int end, bool disposeStream)
        {
            _buffer = new ReaderBuffer(stream, buffer, begin, end, disposeStream);
        }

        /// <summary>
        /// <see langword="true"/> indicating that reader has reached end of JSON input,
        /// otherwise <see langword="false"/>.
        /// </summary>
        public bool EoJ => _buffer.EoF;

        /// <summary>
        /// <see cref="byte"/> value of current position of reader. <see langword="null"/> when
        /// reader has reached <see cref="EoJ"/>.
        /// </summary>
        public byte? Current => EoJ ? null : _buffer.Current;

        /// <summary>
        /// Total number of <see cref="byte"/>s observed by the reader since the very beginning (0-based position).
        /// </summary>
        public long Position => _buffer.Position;

        /// <summary>
        /// Current capacity as total number of <see cref="byte"/>s.
        /// </summary>
        public int Capacity => _buffer.Capacity();

        private bool InRange => !EoJ;

        /// <summary>
        /// Provides a convenient way to asynchronously enumerate over elements of a JSON array (one at a time).
        /// For every iteration, such mechanism produces <see cref="RawJson"/>, where <see cref="RawJson.Value"/> represents
        /// entire value-form (including structural characters, string quotes etc.) of such an individual
        /// element &amp; <see cref="RawJson.Type"/> indicates underlying JSON element type. 
        /// Any standard JSON serializer can be used to deserialize <see cref="RawJson.Value"/>
        /// to obtain an instance of corresponding .Net type.
        /// </summary>
        /// <param name="ensureEoj"><see langword="false"/> to ignore leftover JSON after <see cref="JsonConst.ArrayEndByte"/>.
        /// <see langword="true"/> to ensure that no data is present after <see cref="JsonConst.ArrayEndByte"/>. However, both
        /// single line and multiline comments are allowed after <see cref="JsonConst.ArrayEndByte"/> until <see cref="EoJ"/>.</param>
        /// <param name="token">Cancellation token to observe.</param>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        public IEnumerable<RawJson> EnumerateRawJsonArrayElementAsync(bool ensureEoj,
            CancellationToken token = default)
        {
            ReadIsBeginArrayWithVerifyAsync(token);
            while (!ReadIsEndArrayAsync(ensureEoj, token))
            {
                var next = GetCurrentRawAsync(true, token);
                if (next.Type == JsonType.Nothing)
                {
                    throw new JsonArrayPartParsingException($"Expected a valid JSON element or end of JSON array. " +
                        $"0-Based Position = {Position}.");
                }
                yield return next;
            }
        }

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it checks
        /// if value is <see cref="JsonConst.ArrayBeginByte"/>. If the value matches, then reader advances 
        /// its current position to next <see cref="byte"/> in the sequence or to end of JSON. If the value does NOT match,
        /// reader position is maintained on the current byte and an error 
        /// (of type <see cref="JsonArrayPartParsingException"/>) is thrown.
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        public void ReadIsBeginArrayWithVerifyAsync(CancellationToken token = default)
        {
            if (!ReadIsBeginArrayAsync(token))
            {
                if (InRange)
                {
                    throw new JsonArrayPartParsingException("Invalid byte value for JSON begin-array. " +
                                                            $"Expected = {JsonConst.ArrayBeginByte}, " +
                                                            $"Found = {(char)Current!}, " +
                                                            $"0-Based Position = {Position}.");
                }
                throw new JsonArrayPartParsingException("Reached end, unable to find JSON begin-array." +
                                                        $"0-Based Position = {Position}.");
            }
        }

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
        /// <see langword="true"/> if value is <see cref="JsonConst.ArrayBeginByte"/>. If the value matches, 
        /// then reader advances its current position to next <see cref="byte"/> in the sequence or to end of JSON.
        /// Otherwise, it returns <see langword="false"/> when current byte is NOT <see cref="JsonConst.ArrayBeginByte"/> and
        /// reader position is maintained on the current byte.
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        public bool ReadIsBeginArrayAsync(CancellationToken token = default)
        {
            return ReadIsGivenByteAsync(JsonConst.ArrayBeginByte, token);
        }

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
        /// <see langword="true"/> if value is <see cref="JsonConst.ArrayEndByte"/>. If the value matches, 
        /// then reader advances its current position to next <see cref="byte"/> in the sequence or to end of JSON.
        /// Otherwise, it returns <see langword="false"/> when current byte is NOT <see cref="JsonConst.ArrayEndByte"/> and
        /// reader position is maintained on the current byte.
        /// </summary>
        /// <param name="ensureEoj"><see langword="false"/> to ignore any text (JSON or not) after 
        /// observing <see cref="JsonConst.ArrayEndByte"/>.
        /// <see langword="true"/> to ensure that no data is present after <see cref="JsonConst.ArrayEndByte"/>. However, both
        /// single line and multiline comments are allowed before <see cref="EoJ"/>.</param>
        /// <param name="token">Cancellation token to observe</param>
        public bool ReadIsEndArrayAsync(bool ensureEoj, CancellationToken token = default)
        {
            var reply = ReadIsGivenByteAsync(JsonConst.ArrayEndByte, token);
            if(ensureEoj && reply)
            {
                //we need to make sure only comments exists or we reached EOJ!
                SkipWhiteSpaceAsync(token);
                if(!EoJ)
                {
                    throw new JsonArrayPartParsingException($"Expected End Of JSON after encountering ']'. " +
                                                            $"0-Based Position = {Position}.");
                }
            }
            return reply;
        }

        /// <summary>
        /// Reads the current JSON element as <see cref="RawJson"/>. If reaches <see cref="EoJ"/> or
        /// encounters <see cref="JsonConst.ArrayEndByte"/>, returned <see cref="RawJson.Type"/> is
        /// <see cref="JsonType.Nothing"/>.
        /// <para>
        /// One should prefer <see cref="EnumerateRawJsonArrayElementAsync(bool, CancellationToken)"/>
        /// to parse well-structured JSON stream over this method.
        /// This method is to parse non-standard chain of JSON elements separated by ',' (or not).
        /// </para>
        /// </summary>
        /// <param name="withVerify"><see langword="true"/> to verify the presence of ',' or ']' (but not ',]')
        /// after successfully parsing the current JSON element; <see langword="false"/> otherwise.</param>
        /// <param name="token">Cancellation token to observe.</param>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        public RawJson GetCurrentRawAsync(bool withVerify = true, CancellationToken token = default)
        {
            SkipWhiteSpaceAsync(token);
            if (!InRange || _buffer.Current == JsonConst.ArrayEndByte) return new RawJson(JsonType.Nothing, Array.Empty<byte>());
            _buffer.SkipUntilCurrent();
            var type = SkipUntilNextRawAsync(token);
            var currentRaw = _buffer.GetUntilCurrent();

            if(withVerify)
            {
                ReadIsValueSeparationOrEndWithVerifyAsync(JsonConst.ArrayEndByte,
                        "array",
                        "',' or ']' (but not ',]')",
                        token);
            }
            else
            {
                ReadIsGivenByteAsync(JsonConst.ValueSeparatorByte, token);
            }
            return new RawJson(type, currentRaw);
        }

        private JsonType SkipUntilNextRawAsync(CancellationToken token)
        {
            return _buffer.Current switch
            {
                JsonConst.ArrayBeginByte => SkipArrayAsync(token),
                JsonConst.ObjectBeginByte => SkipObjectAsync(token),
                JsonConst.StringQuoteByte => SkipStringAsync(token),
                JsonConst.MinusSignByte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number0Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number1Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number2Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number3Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number4Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number5Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number6Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number7Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number8Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.Number9Byte => SkipNumberWithoutValidationAsync(token),
                JsonConst.FirstOfTrueByte => SkipRueOfTrueWithoutValidationAsync(token),
                JsonConst.FirstOfFalseByte => SkipAlseOfFalseWithoutValidationAsync(token),
                JsonConst.FirstOfNullByte => SkipUllOfNullWithoutValidationAsync(token),
                _ => throw new JsonArrayPartParsingException($"Invalid byte value for start of JSON element. " +
                                                             $"Found = {(char)Current!}, " +
                                                             $"0-Based Position = {Position}.")
            };
        }

        private JsonType SkipArrayAsync(CancellationToken token)
        {
            if (_buffer.MoveNextAsync(token))
            {
                SkipWhiteSpaceWithVerifyAsync("]", token);
                while (_buffer.Current != JsonConst.ArrayEndByte)
                {
                    SkipUntilNextRawAsync(token);
                    ReadIsValueSeparationOrEndWithVerifyAsync(JsonConst.ArrayEndByte,
                            "array",
                            "',' or ']' (but not ',]')",
                            token);
                }
                _buffer.MoveNextAsync(token);
                return JsonType.Arr;
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find valid JSON end-array (']'). " +
                                           $"0-Based Position = {Position}.");
        }

        private JsonType SkipObjectAsync(CancellationToken token)
        {
            if (_buffer.MoveNextAsync(token))
            {
                SkipWhiteSpaceWithVerifyAsync("}", token);
                while (_buffer.Current != JsonConst.ObjectEndByte)
                {
                    if (_buffer.Current != JsonConst.StringQuoteByte)
                    {
                        throw new JsonArrayPartParsingException($"Invalid byte value for start of Object Property Name. " +
                            $"Expected = {JsonConst.StringQuoteByte}, " +
                            $"Found = {(char)Current!}, " +
                            $"0-Based Position = {Position}.");
                    }
                    SkipStringAsync(token);
                    SkipWhiteSpaceWithVerifyAsync(":", token);
                    _buffer.StepBack();
                    NextExpectedOrThrowAsync(JsonConst.NameSeparatorByte, token, "Object property");
                    _buffer.MoveNextAsync(token);
                    SkipWhiteSpaceWithVerifyAsync("Object property value", token);
                    SkipUntilNextRawAsync(token);
                    ReadIsValueSeparationOrEndWithVerifyAsync(JsonConst.ObjectEndByte,
                            "Object property",
                            "',' or '}' (but not ',}')",
                            token);
                }
                _buffer.MoveNextAsync(token);
                return JsonType.Obj;
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find valid JSON end-object ('}}'). " +
                                           $"0-Based Position = {Position}.");
        }

        private void ReadIsValueSeparationOrEndWithVerifyAsync(byte end, string partOf, string expected, CancellationToken token)
        {
            if (ReadIsValueSeparationOrEndAsync(end, token)) return;
            if (InRange)
            {
                throw new JsonArrayPartParsingException($"Invalid byte value for '{partOf}'. " +
                    $"Expected = {expected}, " +
                    $"Found = {(char)Current!}, " +
                    $"0-Based Position = {Position}.");
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find '{end}'. " +
                                           $"0-Based Position = {Position}.");
        }

        private bool ReadIsValueSeparationOrEndAsync(byte end, CancellationToken token)
        {
            SkipWhiteSpaceAsync(token);
            if (!InRange) return false;
            if (_buffer.Current == end) return true;
            if (_buffer.Current != JsonConst.ValueSeparatorByte) return false;
            _buffer.MoveNextAsync(token);
            SkipWhiteSpaceAsync(token);
            return InRange && _buffer.Current != end;
        }

        private JsonType SkipStringAsync(CancellationToken token)
        {
            while (_buffer.MoveNextAsync(token))
            {
                switch (_buffer.Current)
                {
                    case JsonConst.ReverseSlashByte:
                        if (_buffer.MoveNextAsync(token))
                        {
                            switch (_buffer.Current)
                            {
                                case JsonConst.ReverseSlashByte:
                                case JsonConst.ForwardSlashByte:
                                case JsonConst.StringQuoteByte:
                                case JsonConst.LastOfBackspaceInStringByte:
                                case JsonConst.FirstOfFalseByte:
                                case JsonConst.FirstOfNullByte:
                                case JsonConst.FirstOfTrueByte:
                                case JsonConst.LastOfCarriageReturnInStringByte:
                                    continue;
                                case JsonConst.SecondOfHexDigitInStringByte:
                                    //JsonSerializer must handle validation!
                                    //we skip 4 bytes
                                    if (_buffer.MoveNextAsync(token, 4))
                                    {
                                        continue;
                                    }
                                    throw new JsonArrayPartParsingException($"Reached end, unable to find valid Hex-Digits. " +
                                                                   $"0-Based Position = {Position}.");
                                default:
                                    throw new JsonArrayPartParsingException($"Bad JSON escape. " +
                                        $"Expected = \\{JsonConst.ReverseSlashByte} or " +
                                        $"\\{JsonConst.ForwardSlashByte} or " +
                                        $"\\{JsonConst.StringQuoteByte} or " +
                                        $"\\{JsonConst.LastOfBackspaceInStringByte} or " +
                                        $"\\{JsonConst.FirstOfFalseByte} or " +
                                        $"\\{JsonConst.FirstOfNullByte} or " +
                                        $"\\{JsonConst.FirstOfTrueByte} or " +
                                        $"\\{JsonConst.LastOfCarriageReturnInStringByte} or " +
                                        $"\\{JsonConst.SecondOfHexDigitInStringByte}4Hex, " +
                                        $"Found = \\{(char)Current!}, " +
                                        $"0-Based Position = {Position}.");
                            }
                        }
                        throw new JsonArrayPartParsingException($"Reached end, unable to find valid escape character. " +
                                                       $"0-Based Position = {Position}.");
                    case JsonConst.StringQuoteByte:
                        _buffer.MoveNextAsync(token);
                        return JsonType.Str;
                }
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find end-of-string quote '\"'. " +
                                           $"0-Based Position = {Position}.");
        }

        private JsonType SkipNumberWithoutValidationAsync(CancellationToken token)
        {
            //we just take everything until begin of next token (even if number is not valid!)
            //number parsing rules are too much to write here
            //Serializer will do its job during deserialization
            while (_buffer.MoveNextAsync(token))
            {
                switch (_buffer.Current)
                {
                    case JsonConst.MinusSignByte:
                    case JsonConst.PlusSignByte:
                    case JsonConst.ExponentLowerByte:
                    case JsonConst.ExponentUpperByte:
                    case JsonConst.DecimalPointByte:
                    case JsonConst.Number0Byte:
                    case JsonConst.Number1Byte:
                    case JsonConst.Number2Byte:
                    case JsonConst.Number3Byte:
                    case JsonConst.Number4Byte:
                    case JsonConst.Number5Byte:
                    case JsonConst.Number6Byte:
                    case JsonConst.Number7Byte:
                    case JsonConst.Number8Byte:
                    case JsonConst.Number9Byte:
                        continue;
                    default: return JsonType.Num;
                }
            }
            return JsonType.Num;
        }

        private JsonType SkipRueOfTrueWithoutValidationAsync(CancellationToken token)
        {
            //JsonSerializer must handle literal validation!
            //we skip 3 bytes
            if (_buffer.MoveNextAsync(token, 3))
            {
                //this one to move the pointer forward, we don't care
                //about EoF, that's handled by next read!
                _buffer.MoveNextAsync(token);
                return JsonType.Bool;
            }
            throw new JsonArrayPartParsingException($"Reached end while parsing 'true' literal. " +
                                                    $"0-Based Position = {Position}.");
        }

        private JsonType SkipAlseOfFalseWithoutValidationAsync(CancellationToken token)
        {
            //JsonSerializer must handle literal validation!
            //we skip 4 bytes
            if (_buffer.MoveNextAsync(token, 4))
            {
                //this one to move the pointer forward, we don't care
                //about EoF, that's handled by next read!
                _buffer.MoveNextAsync(token);
                return JsonType.Bool;
            }
            throw new JsonArrayPartParsingException($"Reached end while parsing 'false' literal. " +
                                                    $"0-Based Position = {Position}.");
        }

        private JsonType SkipUllOfNullWithoutValidationAsync(CancellationToken token)
        {
            //JsonSerializer must handle literal validation!
            //we skip 3 bytes
            if (_buffer.MoveNextAsync(token, 3))
            {
                //this one to move the pointer forward, we don't care
                //about EoF, that's handled by next read!
                _buffer.MoveNextAsync(token);
                return JsonType.Null;
            }
            throw new JsonArrayPartParsingException($"Reached end while parsing 'null' literal. " +
                                                    $"0-Based Position = {Position}.");
        }

        private void NextExpectedOrThrowAsync(byte expected, CancellationToken token, string partOf)
        {
            if (_buffer.MoveNextAsync(token) && _buffer.Current == expected) return;
            if (InRange)
            {
                throw new JsonArrayPartParsingException($"Invalid byte value while parsing '{partOf}'. " +
                                               $"Expected = {expected}, " +
                                               $"Found = {(char)Current!}, " +
                                               $"0-Based Position = {Position}.");
            }
            throw new JsonArrayPartParsingException($"Reached end while parsing '{partOf}'. " +
                                           $"Expected = {expected}, " +
                                           $"0-Based Position = {Position}.");
        }

        private bool ReadIsGivenByteAsync(byte match, CancellationToken token)
        {
            SkipWhiteSpaceAsync(token);
            if (!InRange || _buffer.Current != match) return false;
            _buffer.MoveNextAsync(token);
            _buffer.SkipUntilCurrent();
            return true;
        }

        private void SkipWhiteSpaceWithVerifyAsync(string jsonToken, CancellationToken token)
        {
            SkipWhiteSpaceAsync(token);
            if (!InRange)
                throw new JsonArrayPartParsingException($"Reached end, expected to find '{jsonToken}'. " +
                                               $"0-Based Position = {Position}.");
        }

        private void SkipWhiteSpaceAsync(CancellationToken token)
        {
            while (InRange)
            {
                switch (_buffer.Current)
                {
                    case JsonConst.SpaceByte:
                    case JsonConst.HorizontalTabByte:
                    case JsonConst.NewLineByte:
                    case JsonConst.CarriageReturnByte:
                        _buffer.MoveNextAsync(token);
                        continue;
                    case JsonConst.ForwardSlashByte:
                        if (!_buffer.MoveNextAsync(token))
                        {
                            throw new JsonArrayPartParsingException("Reached end. " +
                                                           "Can not find correct comment format " +
                                                           "(neither single line comment token '//' " +
                                                           "nor multi-line comment token '/*').");
                        }
                        ReadCommentAsync(token);
                        continue;
                    default: return;
                }
            }
        }

        private void ReadCommentAsync(CancellationToken token)
        {
            switch (_buffer.Current)
            {
                case JsonConst.ForwardSlashByte:
                    while (_buffer.MoveNextAsync(token))
                    {
                        var current = _buffer.Current;
                        if (current != JsonConst.CarriageReturnByte && current != JsonConst.NewLineByte) continue;
                        _buffer.MoveNextAsync(token);
                        return;
                    }
                    //we don't throw if we reach EoJ, we consider comment ended there!
                    //so we get out. If any other token was expected, further parsing will throw
                    //proper error.
                    break;
                case JsonConst.AsteriskByte:
                    while (_buffer.MoveNextAsync(token))
                    {
                        if (_buffer.Current != JsonConst.AsteriskByte) continue;
                        if (_buffer.MoveNextAsync(token) &&
                            _buffer.Current == JsonConst.ForwardSlashByte)
                        {
                            _buffer.MoveNextAsync(token);
                            return;
                        }
                        _buffer.StepBack();
                    }
                    //we need to throw error even if we reached EoJ
                    //coz the comment was not properly terminated!
                    throw new JsonArrayPartParsingException("Reached end. " +
                                                   "Can not find end token of multi line comment(*/).");
                default:
                    throw new JsonArrayPartParsingException("Can not find correct comment format. " +
                        "Found single forward-slash '/' when expected " +
                        "either single line comment token '//' or multi-line comment token '/*'. " +
                        $"0-Based Position = {Position}.");
            }
        }

        /// <summary>
        /// Asynchronous clean up by releasing resources.
        /// </summary>
        public void Dispose()
        {
            _buffer.DisposeAsync();
        }
    }
}