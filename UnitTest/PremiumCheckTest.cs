using System;
using System.Reflection;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using Xunit;
using Moq;

namespace WindesheimAD2021AutoVerzekeringsPremie.UnitTest
{
    public class PremiumCalculationTest
    {
        [Theory]
        [InlineData(100,20000, 2010, 22, "22-07-2020", 8888, 4,(209 / 3D * 1.15D))]
        public void Procent15AddedToPremiumWhenUnder5YearsDriveLicenseStartDate(int PowerInKw, int ValueInEruo, int BuildYear, int Age, string DriveLicenseStartDate, int PostalCode, int NoClaimYears, double Expected)
        {
            //Arrange
            var vehicle = new Vehicle(PowerInKw, ValueInEruo, BuildYear);
            var policyHolder = new PolicyHolder(Age, DriveLicenseStartDate, PostalCode, NoClaimYears);
            
            //Act
            var premiumCalculation = new PremiumCalculation(vehicle, policyHolder, InsuranceCoverage.WA);
            var actulePremium = premiumCalculation.PremiumAmountPerYear;

            //Assert
            Assert.Equal(Expected, actulePremium);
        }
        
        [Theory]
        [InlineData(100,20000, 2010, 26, "22-07-2010", 8888, 4,(209 / 3D * 1D))]
        public void Procent15AddedToPremiumWhenAbove5YearsDriveLicenseStartDate(int PowerInKw, int ValueInEruo, int BuildYear, int Age, string DriveLicenseStartDate, int PostalCode, int NoClaimYears, double Expected)
        {
            //Arrange
            var vehicle = new Vehicle(PowerInKw, ValueInEruo, BuildYear);
            var policyHolder = new PolicyHolder(Age, DriveLicenseStartDate, PostalCode, NoClaimYears);
            
            //Act
            var premiumCalculation = new PremiumCalculation(vehicle, policyHolder, InsuranceCoverage.WA);
            var actulePremium = premiumCalculation.PremiumAmountPerYear;

            //Assert
            Assert.Equal(Expected, actulePremium);
        }
        
     

        [Fact]
        public void UpdatePremiumForNoClaimYearsTest()
        {
            //Arrange
            var policyHolder = new PolicyHolder(23, "01-01-2002", 9999,0);
            var vehicle = new Vehicle(100, 14000, 2012);
            var premiumCalculation = new PremiumCalculation(vehicle, policyHolder, InsuranceCoverage.WA);
            var ExpectedValue = premiumCalculation.PremiumAmountPerYear * (1 - 0.05);
            var policyHolder6 = new PolicyHolder(23, "01-01-2002", 9999, 6);
            //Act
            var premiumCalculation6 = new PremiumCalculation(vehicle, policyHolder6, InsuranceCoverage.WA);


            //Assert
            
            Assert.Equal(ExpectedValue,premiumCalculation6.PremiumAmountPerYear);
        }

   
        [Fact]
        public void PremiumPaymentAmountMonthTest()
        {
            // Arrange
            var vehicle = new Vehicle(90, 13000, 2011);
            var policyHolder = new PolicyHolder(26, "01-01-2002", 6000, 0);

            // Act
            var premiumCalculationsYear = new Mock<PremiumCalculation>(vehicle, policyHolder, InsuranceCoverage.WA);
            var Expected = Math.Round(premiumCalculationsYear.Object.PremiumAmountPerYear / 12, 2);

            // Assert
            Assert.Equal(Expected, premiumCalculationsYear.Object.PremiumPaymentAmount(PremiumCalculation.PaymentPeriod.MONTH));
        }
        
        
        [Fact]
        public void PremiumPaymentAmountYearTest()
        {
            // Arrange
            var vehicle = new Vehicle(90, 13000, 2011);
            var policyHolderWA = new PolicyHolder(26, "01-01-2002", 6000, 0);

            // Act
            var premuimWA = new PremiumCalculation(vehicle, policyHolderWA, InsuranceCoverage.WA);
            var ExpectedValue = Math.Round(premuimWA.PremiumAmountPerYear * 0.975,2);

            // Assert
            Assert.Equal(ExpectedValue, premuimWA.PremiumPaymentAmount(PremiumCalculation.PaymentPeriod.YEAR));
        }
       
        
        
        [Theory]
        [InlineData(100, 900, 100)]
        [InlineData(100, 1000, 100 * 1.05)]
        [InlineData(100, 3599, 100 * 1.05)]
        [InlineData(100, 3601, 100 * 1.02)]
        [InlineData(100, 4499, 100 * 1.02)]
        [InlineData(100, 4501, 100)]
        public void UpdatePremuimForPostalCodeTest(double premuim, int postalCode, double expectedValue)
        {
            // Arrange

            var postalCodeUpdateMethod = typeof(PremiumCalculation).GetMethod("UpdatePremiumForPostalCode",
                BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            
            // Act 
            var actualValue = postalCodeUpdateMethod.Invoke(null, new object[] {premuim, postalCode});

            //Assert
            Assert.Equal(expectedValue,actualValue);
        }

    }
    
}
