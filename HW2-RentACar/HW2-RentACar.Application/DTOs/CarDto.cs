using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public double Price { get; set; }
    }
}
