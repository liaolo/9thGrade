using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9thGrade
{

    public class Passport
    {
        public static void UnitTest()
        {
            Passport p1 = new Passport("Yakir", 111111, new Date(1, 1, 2030));
            Console.WriteLine("---- Test 1: Create + ToString ----");
            Console.WriteLine(p1.ToString());
            Console.WriteLine();

            Date check1 = new Date(1, 1, 2025);
            Console.WriteLine("---- Test 2: IsValid (before expiry) ----");
            Console.WriteLine(p1.IsValid(check1)); 
            Console.WriteLine();

            Date check2 = new Date(1, 1, 2030);
            Console.WriteLine("---- Test 3: IsValid (same as expiry) ----");
            Console.WriteLine(p1.IsValid(check2)); 
            Console.WriteLine();

            Date check3 = new Date(1, 1, 2035);
            Console.WriteLine("---- Test 4: IsValid (after expiry) ----");
            Console.WriteLine(p1.IsValid(check3));
            Console.WriteLine();

            Console.WriteLine("---- Test 5: SetExpiryDate ----");
            p1.SetExpiryDate(new Date(1, 1, 2040));
            Console.WriteLine(p1.IsValid(check3)); 
            Console.WriteLine();

            Console.WriteLine("---- Test 6: Copy Constructor ----");
            Passport p2 = new Passport(p1);

            p1.SetExpiryDate(new Date(1, 1, 2026));

            Console.WriteLine("p1 valid in 2035? (צריך false)");
            Console.WriteLine(p1.IsValid(check3)); 

            Console.WriteLine("p2 valid in 2035? (צריך true כי נשאר 2040)");
            Console.WriteLine(p2.IsValid(check3)); 
        }

        private string name;
        private int number;
        private Date expiryDate;

        public Passport(string name, int number, Date expiryDate)
        {
            this.name = name;
            this.number = number;
            this.expiryDate = new Date(expiryDate);
        }

        public Passport(Passport passport)
        {
            this.name = passport.name;
            this.number = passport.number;
            this.expiryDate = new Date(passport.expiryDate);
        }

        public override string ToString()
        {
            return "Name: " + name + "\nPass. num: " + number + "\nExp date: " + expiryDate;
        }

        public bool IsValid(Date dateChecked)
        {
            return expiryDate.CompareTo(dateChecked) >= 0;
        }

        public void SetExpiryDate(Date expiryDate)
        {
            this.expiryDate = new Date(expiryDate);
        }

        public static Passport[] passportsNotValidOnDate(Passport[] passports)
        {
            Date dateChecked = new Date(1, 1, 2025);
            int countNotValid = 0;
            for (int i = 0; i < passports.Length; i++)
            {
                if (passports[i].IsValid(dateChecked))
                {
                    countNotValid++;
                }
            }
            Passport[] notValidPassports = new Passport[countNotValid];

            return notValidPassports;
        }






    }
}

