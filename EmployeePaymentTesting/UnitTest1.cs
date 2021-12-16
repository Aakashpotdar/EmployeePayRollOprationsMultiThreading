using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookMultiThreding;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace EmployeePaymentTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given10EmployeeDetails_ShouldMatchEmployeeEntries()
        {
            Stopwatch stopwatch = new Stopwatch();
            EmployeePayrollOprations obj3 = new EmployeePayrollOprations();
            EmployeeDetails add = new EmployeeDetails();

            add.EmployeeID = 10;
            add.EmployeeName = "Johnson";
            add.Gender = 'M';
            add.PhoneNumber = 23413234;
            add.Address = "Somever";
            add.Department = "Hr";
            add.Deductions = 3598;
            add.NetPay = 2343;
            add.TaxablePay = 342;
            add.Tax = 4278;
            add.City = "norway";
            add.Country = "UK";
            add.BasicPay = 2736;

            stopwatch.Start();
            obj3.AddDataToDB(add);
            stopwatch.Stop();
        }

        [TestMethod]
        public void GivenEmployeeDetailsWithThreads()
        {
            Stopwatch stopwatch = new Stopwatch();
            EmployeePayrollOprations obj3 = new EmployeePayrollOprations();
            EmployeeDetails add = new EmployeeDetails();
            EmployeeDetails add1 = new EmployeeDetails();


            add.EmployeeID = 10;
            add.EmployeeName = "Johnson";
            add.Gender = 'M';
            add.PhoneNumber = 23413234;
            add.Address = "Somever";
            add.Department = "Hr";
            add.Deductions = 3598;
            add.NetPay = 2343;
            add.TaxablePay = 342;
            add.Tax = 4278;
            add.City = "norway";
            add.Country = "UK";
            add.BasicPay = 2736;

            add1.EmployeeID = 11;
            add1.EmployeeName = "son";
            add1.Gender = 'M';
            add1.PhoneNumber = 413234;
            add1.Address = "SomeverOnEarth";
            add1.Department = "Account";
            add1.Deductions = 3594;
            add1.NetPay = 533;
            add1.TaxablePay =542;
            add1.Tax = 2224;
            add1.City = "Parise";
            add1.Country = "US";
            add1.BasicPay = 2736;

            stopwatch.Start();
            
            Parallel.Invoke(() =>
            {
                obj3.AddDataToDB(add);
            },
            () =>
            {
                obj3.AddDataToDB(add1);
            }
            );
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;

               string elapsedTime = String.Format("{0:00}:{1:00}",ts.Hours, ts.Minutes);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
