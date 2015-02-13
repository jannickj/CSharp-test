using System.Collections.Generic;
using NUnit.Framework;

namespace Opg1.Tests
{
    [TestFixture]
    public class FindNearestTests
    {
        [Test]
        public void FindNearest_ExactMatch_ReturnMatch()
        {
            // Arrange
            var list = new List<int> { 1, 6, 9, 3 };

            // Act
            var found = list.FindNearest(3);

            // Assert
            Assert.AreEqual(3, found);
        }

        [Test]
        public void FindNearest_EmptyList_ReturnNull()
        {
            // Arrange
            var list = new List<int> { };

            // Act
            var found = list.FindNearest(3);

            // Assert
            Assert.AreEqual(null, found);
        }

        [Test]
        public void FindNearest_MatchLowerBound_ReturnLowerMatch()
        {
            // Arrange
            var list = new List<int> { 1, 3, 6, 9 };

            // Act
            var found = list.FindNearest(4);

            // Assert
            Assert.AreEqual(3, found);
        }

        [Test]
        public void FindNearest_MatchUpperBound_ReturnUpperMatch()
        {
            // Arrange
            var list = new List<int> { 1, 3, 6, 9 };

            // Act
            var found = list.FindNearest(5);

            // Assert
            Assert.AreEqual(6, found);
        }

        [Test]
        public void FindNearest_MultipleMatches_ReturnFirstMatch()
        {
            // Arrange
            var list = new List<int> { 1, 6, 4, 9 }; //fixed to have multiple matches
            
            // Act
            var found = list.FindNearest(5);

            // Assert
            Assert.AreEqual(6, found);
        }

        [Test]
        public void FindNearest_MultipleMatchesAroundZero_ReturnFirstMatch()
        {
            // Arrange
            var list = new List<int> { 1, 0, -3, -2 };

            // Act
            var found = list.FindNearest(-1);

            // Assert
            Assert.AreEqual(0, found);
        }
    }
}
