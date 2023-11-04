using DevFast.Net.Extensions.SystemTypes;

namespace DevFast.Net.Extensions.Tests.SystemTypes
{
    [TestFixture]
    public class EnumerablesTests
    {
        [Test]
        public void ForEach_Calls_The_Lambda_With_Given_Token()
        {
            var val = 0;
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Action<int, CancellationToken> lambda = (x, t) =>
            {
                val = x;
                That(t, Is.EqualTo(token));
            };
            new[] { 1 }.ForEach(lambda, token);
            That(val, Is.EqualTo(1));
        }

        [Test]
        public async Task ForEachAsync_On_Enumerable_Calls_The_Lambda_With_Given_Token()
        {
            var val = 0;
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Func<int, CancellationToken, ValueTask> lambda = (x, t) =>
            {
                val = x;
                That(t, Is.EqualTo(token));
                return ValueTask.CompletedTask;
            };
            await new[] { 1 }.ForEachAsync(lambda, token).ConfigureAwait(false);
            That(val, Is.EqualTo(1));
        }

        [Test]
        public async Task ForEachAsync_On_AsyncEnumerable_Calls_The_Lambda_With_Given_Token()
        {
            var val = 1;
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Func<int, CancellationToken, ValueTask> lambda = (x, t) =>
            {
                val = x;
                That(t, Is.EqualTo(token));
                return ValueTask.CompletedTask;
            };
            await new[] { 1, 2, 3, 4 }.SelectAsync((x,_) => ValueTask.FromResult(x), token).ForEachAsync(lambda, token).ConfigureAwait(false);
            That(val, Is.EqualTo(4));
        }

        [Test]
        public async Task SelectAsync_On_Enumerable_Calls_The_Lambda_With_Given_Token()
        {
            var val = 1;
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Func<int, CancellationToken, ValueTask> lambda = (x, _) =>
            {
                That(x, Is.EqualTo(val++));
                return ValueTask.CompletedTask;
            };
            await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, t) =>
            {
                await Task.CompletedTask;
                That(t, Is.EqualTo(token));
                return x + 1;
            }, token).ForEachAsync(lambda, token).ConfigureAwait(false);
            That(val, Is.EqualTo(6));
        }

        [Test]
        public async Task SelectAsync_On_AsyncEnumerable_Calls_The_Lambda_With_Given_Token()
        {
            var val = 2;
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Func<int, CancellationToken, ValueTask> lambda = (x, _) =>
            {
                That(x, Is.EqualTo(val++));
                return ValueTask.CompletedTask;
            };
            await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x + 1;
            }, token).SelectAsync(async (x, t) =>
            {
                await Task.CompletedTask;
                That(t, Is.EqualTo(token));
                return x + 1;
            }, token).ForEachAsync(lambda, token).ConfigureAwait(false);
            That(val, Is.EqualTo(7));

            val = 2;
            await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x + 1;
            }, token).SelectAsync((x, t) =>
            {
                That(t, Is.EqualTo(token));
                return x + 1;
            }, token).ForEachAsync(lambda, token).ConfigureAwait(false);
            That(val, Is.EqualTo(7));
        }

        [Test]
        public async Task SkipAsync_Does_What_It_Says()
        {
            var l = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }).SkipAsync(2).ToListAsync().ConfigureAwait(false);
            That(l, Has.Count.EqualTo(3));
            That(l, Has.Member(2));
            That(l, Has.Member(3));
            That(l, Has.Member(4));
            l = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }).SkipAsync(10).ToListAsync().ConfigureAwait(false);
            That(l, Is.Empty);
        }

        [Test]
        public async Task TakeAsync_Does_What_It_Says()
        {
            var l = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }).SkipAsync(2).TakeAsync(2).ToListAsync().ConfigureAwait(false);
            That(l, Has.Count.EqualTo(2));
            That(l, Has.Member(2));
            That(l, Has.Member(3));
            l = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }).SkipAsync(10).TakeAsync(5).ToListAsync().ConfigureAwait(false);
            That(l, Is.Empty);
            l = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }).SkipAsync(0).TakeAsync(10).ToListAsync().ConfigureAwait(false);
            That(l, Has.Count.EqualTo(5));
            That(l, Has.Member(0));
            That(l, Has.Member(1));
            That(l, Has.Member(2));
            That(l, Has.Member(3));
            That(l, Has.Member(4));
        }

        [Test]
        public async Task WhereAsync_Uses_Predicate_With_Given_Token_For_Item_Selection()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var l = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }, token).WhereAsync((x, t) =>
            {
                That(t, Is.EqualTo(token));
                return ValueTask.FromResult(x > 3);
            }, token).ToListAsync(token).ConfigureAwait(false);
            Multiple(() =>
            {
                That(l, Has.Count.EqualTo(1));
                That(l, Has.Member(4));
            });
            l = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }, token).WhereAsync((x, t) =>
            {
                That(t, Is.EqualTo(token));
                return x > 3;
            }, token).ToListAsync(token).ConfigureAwait(false);
            Multiple(() =>
            {
                That(l, Has.Count.EqualTo(1));
                That(l, Has.Member(4));
            });
        }

        [Test]
        public async Task CountAsync_N_CountLongAsync_Properly_Counts_Elements()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var l = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }, token).CountAsync(token).ConfigureAwait(false);
            var ul = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }, token).CountLongAsync(token).ConfigureAwait(false);
            Multiple(() =>
            {
                That(l, Is.EqualTo(5));
                That(ul, Is.EqualTo(5));
            });
            l = await Array.Empty<int>().SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }, token).CountAsync(token).ConfigureAwait(false);
            ul = await Array.Empty<int>().SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }, token).CountLongAsync(token).ConfigureAwait(false);
            Multiple(() =>
            {
                That(l, Is.EqualTo(0));
                That(ul, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task ToListAsync_Returns_All_The_Elements_As_List()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var l = await new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
            {
                await Task.CompletedTask;
                return x;
            }, token).ToListAsync(token).ConfigureAwait(false);
            Multiple(() =>
            {
                That(l, Has.Count.EqualTo(5));
                That(l, Has.Member(0));
                That(l, Has.Member(1));
                That(l, Has.Member(2));
                That(l, Has.Member(3));
                That(l, Has.Member(4));
            });

            cts.Cancel();
            ThrowsAsync<OperationCanceledException>(async () => await new[] { 0 }.SelectAsync(
                async (x, t) =>
                {
                    await Task.CompletedTask;
                    t.ThrowIfCancellationRequested();
                    return x;
                }, CancellationToken.None).ToListAsync(token).ConfigureAwait(false));
        }

        [Test]
        public async Task ToChunksAsync_Returns_Several_Chunks_When_AsyncEnumerable_Has_More_Elements_Than_Chunk_Size()
        {
            var cnt = 2;
            var starting = 0;
            await foreach (var c in new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
                           {
                               await Task.CompletedTask;
                               return x;
                           }).ToChunksAsync(2).ConfigureAwait(false))
            {
                if (starting == 4)
                {
                    cnt = 1;
                }
                else
                {
                    That(c, Has.Member(starting++));
                }
                That(c, Has.Count.EqualTo(cnt));
                That(c, Has.Member(starting++));
            }
            That(starting, Is.EqualTo(5));
            cnt = 2;
            starting = 0;
            List<int>? l = null;
            await foreach (var c in new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
                           {
                               await Task.CompletedTask;
                               return x;
                           }).ToChunksAsync(2, reUseList: true).ConfigureAwait(false))
            {
                if (starting == 4)
                {
                    cnt = 1;
                }
                else
                {
                    That(c, Has.Member(starting++));
                }

                Multiple(() =>
                {
                    That(c, Has.Count.EqualTo(cnt));
                    That(c, Has.Member(starting++));
                });
                l ??= c;
                Multiple(() =>
                {
                    That(l, Is.Not.Null);
                    That(ReferenceEquals(l, c), Is.True);
                });
            }
            That(starting, Is.EqualTo(5));
        }

        [Test]
        public async Task ToChunksAsync_Returns_All_Elements_When_Chunk_Size_IsGreater_Than_Elements_In_AsyncEnumerable()
        {
            var starting = 0;
            await foreach (var c in new[] { 0, 1, 2, 3, 4 }.SelectAsync(async (x, _) =>
                           {
                               await Task.CompletedTask;
                               return x;
                           }).ToChunksAsync(6).ConfigureAwait(false))
            {
                That(c, Has.Count.EqualTo(5));
                That(c, Has.Member(starting++));
                That(c, Has.Member(starting++));
                That(c, Has.Member(starting++));
                That(c, Has.Member(starting++));
                That(c, Has.Member(starting++));
            }
            That(starting, Is.EqualTo(5));
        }
    }
}