using System;
using NUnit.Framework;
using Task2_RussianPhonetics;

namespace UnitTest
{
    [TestFixture]
    public class RussianPhoneticsTest
    {
        LettersInSounds sound = new LettersInSounds();

        [TestCase('f', 0)]
        [TestCase('а', 6)]
        [TestCase('б', 1)]
        [TestCase('е', 6)]
        [TestCase('т', 3)]
        [TestCase('ч', 4)]
        [Test]
        public void WhatIsThisLetterTest(char sym, int result)
        {
            int actual = sound.WhatIsThisLetter(sym);
            Assert.AreEqual(result, actual);
        }

        [TestCase("молоко+", "малако")]
        [TestCase("ёлка", @"й'олка")]
        [TestCase("сде+лать", @"зд'элат'")]
        [TestCase("еме+ля", @"й'эм'эл'а")]
        [TestCase("гвоздь", @"гвост'")]
        [TestCase("льётся", @"л'отс'а")]
        [TestCase("верне+е", "в'эрн'эй'э")]
        [Test]
        public void FromLetterToSoundTest(string someStr, string result)
        {
            sound = new LettersInSounds(someStr);
            string actual = sound.FromLettersToSounds();
            Assert.AreEqual(result, actual);
        }

        [TestCase("моло+ко+")]
        [TestCase("ёлка+")]
        [TestCase("емеля")]
        [TestCase("гво+здь")]
        [TestCase("льётсяdf")]
        [TestCase("втрп")]
        [Test]
        public void FromLetterToSound_FormattException(string someStr)
        {
            Assert.Throws<Exception>
            (
                () => sound = new LettersInSounds(someStr)
            );
        }

        [TestCase('о', 'а', "а")]
        [TestCase('ё', 'ь', @"й'о")]
        [TestCase('а', 'п', "а")]
        [TestCase('е', 'е', @"й'э")]
        [Test]
        public void ForNonShockVowelTest(char sym, char pastSym, string result)
        {
            sound = new LettersInSounds();
            string actual = sound.ForNonShockVowel(sym, pastSym);
            Assert.AreEqual(result, actual);
        }

        [TestCase('о', 'а', "о")]
        [TestCase('ё', 'ь', @"й'о")]
        [TestCase('а', 'п', "а")]
        [TestCase('е', 'е', @"й'э")]
        [Test]
        public void ForShockVowelTest(char sym, char pastSym, string result)
        {
            sound = new LettersInSounds();
            string actual = sound.ForShockVowel(sym, pastSym);
            Assert.AreEqual(result, actual);
        }

        [TestCase('ч', 'а', "ч")]
        [TestCase('х', 'ь', @"х'")]
        [Test]
        public void ForNonPairedDeafTest(char sym, char nextSym, string result)
        {
            sound = new LettersInSounds();
            string actual = sound.ForNonPairedDeaf(sym, nextSym);
            Assert.AreEqual(result, actual);
        }

        [TestCase('р', 'а', "р")]
        [TestCase('л', 'ь', @"л'")]
        [Test]
        public void ForNonPairedRingingTest(char sym, char nextSym, string result)
        {
            sound = new LettersInSounds();
            string actual = sound.ForNonPairedRinging(sym, nextSym);
            Assert.AreEqual(result, actual);
        }

        [TestCase('с', 'р', "c")]
        [TestCase('с', 'б', @"с")]
        [TestCase('т', 'а', @"т")]
        [TestCase('т', 'е', @"т'")]
        [Test]
        public void ForPairedDeafTest(char sym, char nextSym, string result)
        {
            sound = new LettersInSounds();
            string actual = sound.ForPairedDeaf(sym, nextSym);
            Assert.AreEqual(result, actual);
        }

        [TestCase('з', 'р', "з")]
        [TestCase('з', 'с', @"з")]
        [TestCase('з', 'а', @"з")]
        [TestCase('з', 'е', @"з'")]
        [TestCase('з', 'с', @"с")]
        [Test]
        public void ForPairedRingingTest(char sym, char nextSym, string result)
        {
            sound = new LettersInSounds();
            string actual = sound.ForPairedRinging(sym, nextSym);
            Assert.AreEqual(result, actual);
        }
    }
}
