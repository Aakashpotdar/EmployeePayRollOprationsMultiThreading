using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookMultiThreding
{
    public class EmployeePayrollOprations
    {
        public static string ConnectionLink = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionLink);

        public void AddDataToDB(EmployeeDetails a)
        {
           lock(this){
                try
                {
                    using (this.connection)
                    {
                        SqlCommand com = new SqlCommand("AAddAddress", this.connection);
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Id", a.EmployeeID);
                        com.Parameters.AddWithValue("@EmployeeName", a.EmployeeName);
                        com.Parameters.AddWithValue("@PhoneNumber", a.PhoneNumber);
                        com.Parameters.AddWithValue("@Address", a.Address);
                        com.Parameters.AddWithValue("@Department", a.Department);
                        com.Parameters.AddWithValue("@Gender", a.Gender);
                        com.Parameters.AddWithValue("@BasicPay", a.BasicPay);
                        com.Parameters.AddWithValue("@Deductions", a.Deductions);
                        com.Parameters.AddWithValue("@TaxablePay", a.TaxablePay);
                        com.Parameters.AddWithValue("@NetPay", a.NetPay);
                        com.Parameters.AddWithValue("@Tax", a.Tax);
                        com.Parameters.AddWithValue("@City", a.City);
                        com.Parameters.AddWithValue("@Country", a.Country);

                        this.connection.Open();
                        var result = com.ExecuteNonQuery();
                        this.connection.Close();


                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    this.connection.Close();
                } 
            }

        }
    }
}
