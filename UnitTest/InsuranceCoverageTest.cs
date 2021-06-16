using System;
using System.Reflection;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using Xunit;
using Moq;

namespace WindesheimAD2021AutoVerzekeringsPremie.UnitTest
{
    public class InsuranceCoverageTest
    {
        
        [Fact]
        public void PremuimCalculationInsuranceCoverageAllRiskTest()
        {
            // Arrange
            var vehicle = new Vehicle(90, 13000, 2011);
            var policyHolderWA = new PolicyHolder(26, "01-01-2002", 6000, 0);

            // Act
            var premuimWA = new PremiumCalculation(vehicle, policyHolderWA, InsuranceCoverage.WA);
            var premuimAllRisk = new PremiumCalculation(vehicle, policyHolderWA, InsuranceCoverage.ALL_RISK);

            // Assert
            Assert.Equal(premuimWA.PremiumAmountPerYear * 2, premuimAllRisk.PremiumAmountPerYear);
        }
        
        
        [Fact]
        public void PremuimCalculationInsuranceCoverageWATest()
        {
            // Arrange
            var vehicle = new Vehicle(90, 13000, 2011);
            var policyHolderWA = new PolicyHolder(26, "01-01-2002", 6000, 0);

            // Act
            var premuimWA = new PremiumCalculation(vehicle, policyHolderWA, InsuranceCoverage.WA);
            var premuimAllRisk = new PremiumCalculation(vehicle, policyHolderWA, InsuranceCoverage.WA_PLUS);

            // Assert
            Assert.Equal(premuimWA.PremiumAmountPerYear * 1.2, premuimAllRisk.PremiumAmountPerYear);
        }
        
    }
    
    
}