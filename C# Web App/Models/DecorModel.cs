using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeDecor.Models
{
    public class DecorModel
    {// Inventory Table in Database with fields Furniture_code, Furniture_name, Furniture_type, Date_of_purchase, Unit
        [Key]
        public int Resource_code { get; set; }
        [Required (ErrorMessage ="Resource Name is required.")]
        public string Resource_name { get; set; }

        public string Resource_description { get; set; }
        public string Color { get; set; }

        //[Required(ErrorMessage = "Size is a mandatory field")]
        public String Size { get; set; }

        [Required(ErrorMessage = "Quantity is a mandatory field")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public int Facility_code { get; set; }
        public virtual FacilityModel FacilityModel { get; set; }
        public bool isActive { get; set; }
    }
}
