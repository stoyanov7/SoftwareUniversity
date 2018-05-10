namespace P03_SalesDatabase.Initializer.Generators
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Data.Models;

    public static class CustomerGenerator
    {
        private static readonly Random random = new Random();
                
        private static readonly string[] Names =
        {
            "Petur",
            "Ivan",
            "Georgi",
            "Alexander",
            "Stefan",
            "Vladimir",
            "Svetoslav",
            "Kaloyan",
            "Mihail",
            "Stamat"
        };
        
        private static readonly string[] Domains =
        {
            "mail.bg",
            "abv.bg",
            "gmail.com",
            "hotmail.com",
            "softuni.bg",
            "students.softuni.bg"
        };
                
        private static readonly string[] CreditCardNumber =
        {
            "373893837762886",
            "379893748382141",
            "379472540123142",
            "344058699741941",
            "345607238699199",
            "374413738046740",
            "341379545322139"
        };

        public static Customer NewCustomer(SalesContext context)
        {
            var name = GenerateName(Names);
            var domain = GenerateDomain(Domains);
            var creditCardNumber = GenerateCreditCardNumber(CreditCardNumber);

            var customer = new Customer
            {
                Name = name,
                CreditCardNumber = creditCardNumber,
                Email = domain
            };

            return customer;
        }

        private static string GenerateName(IReadOnlyList<string> names)
        {
            var index = random.Next(0, names.Count);
            var name = names[index];

            return name;
        }

        private static string GenerateDomain(IReadOnlyList<string> domains)
        {
            var index = random.Next(0, domains.Count);
            var domain = domains[index];

            return domain;
        }

        private static string GenerateCreditCardNumber(IReadOnlyList<string> creaditCardNumbers)
        {
            var index = random.Next(0, creaditCardNumbers.Count);
            var creditCardNumber = creaditCardNumbers[index];

            return creditCardNumber;
        }
    }
}