using Backend.Services;
using Manero.Test.UnitTests.Fadi;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Test.UnitTests.Fadi
{
    public class RatingStarService_Tests
    {
        [Fact]
        public void AverageRatingStar_Should_Return_Correct_Average()
        {
            // Arrange
            var ratingStarService = new RatingStarService();
            var ratingStarList = new List<float> { 2.5f, 3.0f, 4.5f, 5.0f };
            var expectedAverage = 3.75f;

            // Act
            var actualAverage = ratingStarService.AverageRatingStar(ratingStarList);

            // Assert
            Assert.Equal(expectedAverage, actualAverage);
        }
      
    }
}
