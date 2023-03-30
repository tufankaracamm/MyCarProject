using Business.Concrete;
using Business.Constant;
using DataAccess.Concrete;
using Entities.Concrete;



CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
var result = customerManager.GetAll();
foreach (var customer in result.Data)
{
	Console.WriteLine(customer.CompanyName);
}





