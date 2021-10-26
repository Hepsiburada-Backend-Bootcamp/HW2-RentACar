using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RenACar.Domain.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RentingDayDuration { get; set; }
        public double TotalPrice { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}
