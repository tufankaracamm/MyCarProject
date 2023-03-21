using Business.Concrete;
using Business.Constant;
using DataAccess.Concrete;
using Entities.Concrete;




CarManager carManager = new CarManager(new EfCarDal());

var result = carManager.GetAll();

if(result.Success == true)
{
	foreach (var car in result.Data)
	{
		Console.WriteLine(car.CarName +"/"+ car.Description);
	}
}
else
{
	Console.WriteLine(Messages.MainteNanceTime);
}

