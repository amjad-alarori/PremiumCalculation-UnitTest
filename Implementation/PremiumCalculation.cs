using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindesheimAD2021AutoVerzekeringsPremie.Implementation
{
    internal class PremiumCalculation
    {
        public double PremiumAmountPerYear { get; private set; }
        private readonly int PRECISION = 2;

        internal enum PaymentPeriod
        {
            YEAR,
            MONTH
        }
                
        internal PremiumCalculation(Vehicle vehicle, PolicyHolder policyHolder, InsuranceCoverage coverage)
        {
            
            double premium = 0d;
            premium += CalculateBasePremium(vehicle);

            if(policyHolder.Age < 23 || policyHolder.LicenseAge <= 5)
            {
                premium *= 1.15;
            }

            premium = UpdatePremiumForPostalCode(premium, policyHolder.PostalCode);

            if(coverage == InsuranceCoverage.WA_PLUS)
            {
                premium *= 1.2;
            } else if (coverage == InsuranceCoverage.ALL_RISK)
            {
                premium *= 2;
            }
            
            

            premium = UpdatePremiumForNoClaimYears(premium, policyHolder.NoClaimYears);

            PremiumAmountPerYear = premium;
        }

        private static double UpdatePremiumForNoClaimYears(double premium, int years)
        {
            int NoClaimPercentage = (years - 5) * 5;
            if (NoClaimPercentage > 65)
            {
                NoClaimPercentage = 65;
            }

            if (NoClaimPercentage < 0)
            {
                NoClaimPercentage = 0;
            }
            // hier heb ik aangepast, de unit test vervacht type double om de vergelijking te laten kloppen, de 100 op double gezet. 
            return premium * ((double)(100 - NoClaimPercentage) / 100);
        }

        private static double UpdatePremiumForPostalCode(double premium, int postalCode) => postalCode switch
        {
            // hier heb ik precies gezegd tegen de app wat moet he berekenen tussen 4500 en 3600, zo kan ik makelijk in unit test een inlinedata mee geven.
            >= 1000 and < 3600 => premium * 1.05,
            <= 4500 and > 3600 => premium * 1.02,
            _ => premium,
           
            
        };

        internal double PremiumPaymentAmount(PaymentPeriod period)
        {
           
            double result = period == PaymentPeriod.YEAR ? PremiumAmountPerYear * 0.975 : PremiumAmountPerYear / 12;
            return Math.Round(result, PRECISION);
        }

        internal static double CalculateBasePremium(Vehicle vehicle)
        {
            
            // hier heb ik aangepast, de unit test vervacht type double om de vergelijking te laten kloppen. 
            return ((double)vehicle.ValueInEuros / 100 - vehicle.Age + (double)vehicle.PowerInKw / 5) / 3;
        }
    }
}
