using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application.DTOs
{
    public class RentDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RentingDayDuration { get; set; }
        public double TotalPrice { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
    }
}
