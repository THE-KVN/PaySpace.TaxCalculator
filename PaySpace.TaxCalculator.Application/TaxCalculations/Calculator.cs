namespace PaySpace.TaxCalculator.Application.TaxCalculations
{
    public static class Calculator
    {
        public static double CalculateTax(double annualIncome, string postalCode)
        {
            switch (postalCode.ToLower().Trim())
            {
                case "7441":
                    return CalculateProgressiveTax(annualIncome);
                case "A100":
                    return CalculateFlatValueTax(annualIncome);
                case "7000":
                    return CalculateFlatRateTax(annualIncome);
                case "1000":
                    return CalculateProgressiveTax(annualIncome);
                default:
                    Console.WriteLine("Invalid tax type");
                    return 0;
            }
        }

        public static double CalculateProgressiveTax(double annualIncome)
        {
            double tax = 0;

            if (annualIncome <= 8350)
            {
                tax = annualIncome * 0.1;
            }
            else if (annualIncome <= 33950)
            {
                tax = 8350 * 0.1 + (annualIncome - 8350) * 0.15;
            }
            else if (annualIncome <= 82250)
            {
                tax = 8350 * 0.1 + (33950 - 8350) * 0.15 + (annualIncome - 33950) * 0.25;
            }
            else if (annualIncome <= 171550)
            {
                tax = 8350 * 0.1 + (33950 - 8350) * 0.15 + (82250 - 33950) * 0.25 + (annualIncome - 82250) * 0.28;
            }
            else if (annualIncome <= 372950)
            {
                tax = 8350 * 0.1 + (33950 - 8350) * 0.15 + (82250 - 33950) * 0.25 + (171550 - 82250) * 0.28 + (annualIncome - 171550) * 0.33;
            }
            else
            {
                tax = 8350 * 0.1 + (33950 - 8350) * 0.15 + (82250 - 33950) * 0.25 + (171550 - 82250) * 0.28 + (372950 - 171550) * 0.33 + (annualIncome - 372950) * 0.35;
            }

            return tax;
        }

        public static double CalculateFlatValueTax(double annualIncome)
        {
            if (annualIncome < 200000)
            {
                return 10000;
            }
            else
            {
                return annualIncome * 0.05;
            }
        }

        public static double CalculateFlatRateTax(double annualIncome)
        {
            return annualIncome * 0.175;
        }
    }
}
