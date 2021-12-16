create procedure [dbo].[ApAddAddress]
@Id int,
@EmployeeName varchar(255),
@PhoneNumber int,
@Address varchar(255),
@Department varchar(255),
@Gender varchar(255),
@BasicPay int,
@Deductions int,
@TaxablePay int,
@NetPay int,
@Tax int,
@City varchar(255),
@Country varchar(255)

as 
begin

insert into Employee_Payroll(Id,name,gender,phone_number,address,department,BasicPay,Deduction,TaxablePay,NetPay)
values(@Id,@EmployeeName,@Gender,@PhoneNumber,@Address,@Department,@BasicPay,@Deductions,@TaxablePay,@NetPay)

end

select * from Employee_Payroll