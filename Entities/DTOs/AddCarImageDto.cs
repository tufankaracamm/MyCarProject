using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddCarImageDto : IDto
    {
        public IFormFile? IFormFile { get; set; }
        public int CarId  { get; set; }
    }
}
