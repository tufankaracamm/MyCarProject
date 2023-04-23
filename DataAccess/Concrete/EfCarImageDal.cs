using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarContext>, ICarImageDal
    {

               
        public bool add(CarImage carImage)
        {
            using (CarContext context = new CarContext())
            {
                var AddedEntity = context.Entry(carImage);
                AddedEntity.State= EntityState.Added;
                context.SaveChanges();
                return true;
            }
        }
    }
}
