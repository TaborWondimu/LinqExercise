using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"This is the sum: {sum}");

            var average = numbers.Average();
            Console.WriteLine($"This is the average: {average}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascendingOrder = numbers.OrderBy(x => x);
            Console.WriteLine("This is ascending");
            foreach (var y in ascendingOrder)
            {
                Console.WriteLine(y);
            }
            Console.WriteLine("This is Descending");
            var decsendingOrder = numbers.OrderByDescending(x => x);
            foreach(var x in decsendingOrder)
            {
                Console.WriteLine(x);
            }

            //Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than six");
            var greaterThanSix = numbers.Where(x => x > 6);
            foreach (var num in greaterThanSix)
            {
                Console.WriteLine(num);
            }
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var onlyFour = numbers.OrderBy(x => x);

            Console.WriteLine("Only print four ascending");
            foreach(int num in onlyFour.Take(4))
            {  
              Console.WriteLine(num);
            }
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 25;
            var ascendingAgain = numbers.OrderByDescending(x => x);
            Console.WriteLine("Changed number and sorted in decsending order");
            foreach (var num in ascendingAgain)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("This is for employees");
            Console.WriteLine("==================================");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //DONEPrint all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //DONE Order this in acesnding order by FirstName.
            var names = from individuals in employees
                        where individuals.FirstName.StartsWith("S") || individuals.FirstName.StartsWith("C")
                        orderby individuals.FirstName ascending
                        select individuals;
            Console.WriteLine("Conatins 'S' or 'C' ");
            foreach ( var i in names)
            {
                Console.WriteLine(i.FullName); 
            }
            
            Console.WriteLine("================================");
            Console.WriteLine("This is employee full name and age");
            Console.WriteLine("==================================");
            

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            var nameAbove26 = from individuals in employees
                              where individuals.Age > 26
                              orderby individuals.Age, individuals.FirstName ascending
                              select individuals;


            foreach (var num in nameAbove26)
            {
                Console.WriteLine($"Age:{num.Age} FullName: {num.FirstName}");
            }
            // Done Order this by Age first and then by FirstName in the same result.

            //Print the Sum and then the Average of the employees' YearsOfExperience
            var sumOfExperience = employees.Sum(x => x.YearsOfExperience);
            var employeesAverageExperience = employees.Average(x => x.YearsOfExperience);
            Console.WriteLine("==============================================");
            Console.WriteLine("Sum and Average Years of Experience for Employees");
            Console.WriteLine($"Sum: {sumOfExperience},Years: {employeesAverageExperience}");

            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var printByYOE = from emp in employees
                             where emp.YearsOfExperience <= 10 && emp.Age > 35
                             select emp;
            Console.WriteLine("===============================================");
            Console.WriteLine("This employees have 10 or less years of experience and they are 35 years of age or above");
            foreach(var worker in printByYOE)
            {
                Console.WriteLine($"FullName {worker.FullName}, YOE {worker.YearsOfExperience} Age {worker.Age}");
            }
            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("John", "Smith", 24, 56)).ToList() ;
            
            foreach (var Employee in employees)
            {
                Console.WriteLine($"Full Name {Employee.FullName}, {Employee.Age},{Employee.YearsOfExperience}");
            }
   

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5)); // this should print
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));   // this should print
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7)); // this should print
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
