using System;
using System.Reflection;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using Xunit;
using Moq;


namespace WindesheimAD2021AutoVerzekeringsPremie.UnitTest
{
    public class VehicleTest
    {
        [Fact]
        public void OldVehicleConstructionYearTest()
        {
            // Arrange 
            var constructionYear = 2017;

            // Act
            var vehicle = new Vehicle(100, 20000, constructionYear);

            // Assert
            
            Assert.Equal(4, vehicle.Age);
        }
        
        [Fact]
        public void FreshVehicleConstructionYearTest()
        {
            // Arrange 
            var constructionYear = DateTime.Now.Year;

            // Act
            var vehicle = new Vehicle(100, 20000, constructionYear);

            // Assert
            
            Assert.Equal(0, vehicle.Age);
        }
        
        [Fact]
        public void UpComingVehicleConstructionYearTest()
        {
            // Arrange 
            var constructionYear = DateTime.Now.Year + 1;

            // Act
            var vehicle = new Vehicle(100, 20000, constructionYear);

            // Assert
            
            Assert.Equal(0, vehicle.Age);
        }

    }
    
}
