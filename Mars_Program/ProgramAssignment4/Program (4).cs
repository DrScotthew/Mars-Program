//10-24-21 (Sun.)
//Mars Program
//This program takes user inputs for a name, pay rate, and time for which they are paid and performs calculations based off these.
//It will display the amount made for the employee after taxes have been calculated on the user inputs.


using System;

namespace Mars_Program4
{
    class Program
    {
        static void Main(string[] args)
        {
            string employeeName;
            bool hourly;
            bool monthly;
            string payType;
            float payRate;

            Console.WriteLine("Hello!  Please enter your last name: ");
            employeeName = Console.ReadLine();

            Console.WriteLine("Your employee last name is: {0}", employeeName);
            Console.WriteLine();
            Console.WriteLine("What is your pay type?  Please type 'hourly' or 'monthly.'");
            Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("What is your pay rate based off of your pay type?");
            payRate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Your pay rate: {0}", payRate);
            Console.WriteLine();

            Employee bob = new Employee();
            {
                bob.EmployeeSetValues("Joseph", "Constant", 0, 300, 10.0f, 0.25f, 0);
                bob.CalculatePlanetaryTax();

            }

            Employee newEmployee = new Employee();
            {
                newEmployee.EmployeeSetValues("Jim", employeeName, 0, payRate, 10.0f, 0.25f, 0);
            }

            Console.WriteLine("Total deduction amount is " + bob.CalculateDeductions().ToString());
        }
    }

    public class Employee
    {
        private string Firstname, Lastname;
        //private string hourly;
        //private string monthly;
        private int payType;
        //private string rate;
        private float rate;
        private float ssnTax;
        private float airTax;
        private float planetaryTax;

        public void EmployeeSetValues(string fname, string lname, int newPayType, float newRate, float newSsnTax, float newAirTax, float newPlanetaryTax)
        {
            Firstname = fname; Lastname = lname; payType = newPayType; rate = newRate; ssnTax = newSsnTax; airTax = newAirTax; planetaryTax = newPlanetaryTax;
        }

        public string GetFirstname()
        {
            return Firstname;
        }

        public void SetFirstname(string fname)
        {
            Firstname = fname;
        }

        public string GetLastname()
        {
            return Lastname;
        }

        public void SetLastname(string lname)
        {
            Lastname = lname;
        }

        public int GetPayType()
        {
            return payType;
        }

        public void SetPayType(int newPayType)
        {
            payType = newPayType;
        }

        public float GetRate()
        {
            return rate;
        }

        public void SetRate(float newRate)
        {
            rate = newRate;
        }

        public float GetSsnTax()
        {
            return ssnTax;
        }

        public void SetSsnTax(float newSsnTax)
        {
            ssnTax = newSsnTax;
        }

        public float GetAirTax()
        {
            return airTax;
        }

        public void SetAirTax(float newAirTax)
        {
            airTax = newAirTax;
        }

        public float GetPlanetaryTax()
        {
            return planetaryTax;
        }

        public void CalculatePlanetaryTax()
        {
            if (payType == 0) //If hourly
            {
                if (rate >= 100)
                {
                    planetaryTax = 10.0f;
                }
                else if (rate >= 50)
                {
                    if (Lastname == "Constant")
                    {
                        planetaryTax = 2.0f;
                    }
                    else
                    {
                        planetaryTax = 8.0f;
                    }
                }
                else if (rate < 50)
                {
                    planetaryTax = 5.0f;
                }
            }
            else if (payType == 1) //If salary
            {
                if (Lastname == "Constant")
                {
                    planetaryTax = 0.0f;
                }
                else
                {
                    if (rate >= 10000)
                    {
                        planetaryTax = 22.0f;
                    }
                    else if (rate >= 5000)
                    {
                        planetaryTax = 18.0f;
                    }
                    else if (rate < 5000)
                    {
                        planetaryTax = 15.0f;
                    }
                }
            }

        }

        public float CalculateDeductions()
        {
            float rDeduction = ((rate * (planetaryTax / 100)) + airTax + ((rate * (ssnTax / 100))));
            return rDeduction;
        }

    }

}
