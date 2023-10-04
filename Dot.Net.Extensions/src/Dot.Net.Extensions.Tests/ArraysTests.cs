﻿using static NUnit.Framework.Assert;

namespace Dot.Net.Extensions.Tests
{
    [TestFixture]
    public class ArraysTests
    {
        [Test]
        public void LiftNCopySafe_Throws_ArgumentException_When_Required()
        {
            Throws<ArgumentException>(() => new byte[] { 0 }.LiftNCopySafe(0, 2, 0));
            Throws<ArgumentException>(() => new byte[] { 0 }.LiftNCopySafe(1, 1, 0));
            Throws<ArgumentException>(() => new byte[] { 0 }.LiftNCopySafe(0, 1, 1));
        }

        [Test]
        public void LiftNCopySafe_N_LiftNCopyUnSafe_Copies_Correctly()
        {
            var a = Enumerable.Range(0, 10).Select(x => (byte)x).ToArray();
            a.LiftNCopySafe(0, 5, 5);
            int first = 0, second = 5;
            Multiple(() =>
            {
                That(a[first++], Is.EqualTo(a[second++]));
                That(a[first++], Is.EqualTo(a[second++]));
                That(a[first++], Is.EqualTo(a[second++]));
                That(a[first++], Is.EqualTo(a[second++]));
                That(a[first], Is.EqualTo(a[second]));
            });

            a = Enumerable.Range(0, 10).Select(x => (byte)x).ToArray();
            a.LiftNCopyUnSafe(0, 5, 5);
            first = 0;
            second = 5;
            Multiple(() =>
            {
                That(a[first++], Is.EqualTo(a[second++]));
                That(a[first++], Is.EqualTo(a[second++]));
                That(a[first++], Is.EqualTo(a[second++]));
                That(a[first++], Is.EqualTo(a[second++]));
                That(a[first], Is.EqualTo(a[second]));
            });
        }

        [TestCase(0, 0)]
        [TestCase(1, 2)]
        [TestCase(2, 4)]
        public void DoubleByteCapacity_Works_As_Expected(int initial, int expected)
        {
            var a = Enumerable.Range(0, initial).Select(x => (byte)x).ToArray();
            var b = a.DoubleByteCapacity();
            That(b, Has.Length.EqualTo(expected));
            Enumerable.Range(0, initial).ForEach((x, _) => That(a[x], Is.EqualTo(b[x])), CancellationToken.None);
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 0, 1)]
        [TestCase(2, 9, 9)]
        [TestCase(9, 2, 9)]
        public void EnsureByteCapacity_Works_As_Expected(int initial, int target, int expected)
        {
            var a = Enumerable.Range(0, initial).Select(x => (byte)x).ToArray();
            var b = a.EnsureByteCapacity(target);
            That(b, Has.Length.EqualTo(expected));
            Enumerable.Range(0, initial).ForEach((x, _) => That(a[x], Is.EqualTo(b[x])), CancellationToken.None);
        }
    }
}