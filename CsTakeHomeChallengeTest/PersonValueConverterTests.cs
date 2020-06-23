﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Take_Home_Challenge;
using NUnit.Framework;

namespace CsTakeHomeChallengeTest
{
    [TestFixture]
    class PersonValueConverterTests
    {
        [Test]
        public void Convert_TruetoBlack()
        {
            // Arrange
            var systemUnderTest = new PersonValueConverter();

            // Act
            var result = systemUnderTest.Convert(true, null, null, null);

            // Assert
            Assert.AreEqual(result, "Black");
        }

        [Test]
        public void Convert_FalseToGray()
        {
            // Arrange
            var systemUnderTest = new PersonValueConverter();

            // Act
            var result = systemUnderTest.Convert(false, null, null, null);

            // Assert
            Assert.AreEqual(result, "Gray");
        }
    }
}