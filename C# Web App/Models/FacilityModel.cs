using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeDecor.Models
{
    public class FacilityModel
    {
        [Key]
        public int Facility_code { get; set; }
        [Required(ErrorMessage = "Facility Name is required")]
        public string Facility_name { get; set; }
        [Required(ErrorMessage = "Facility Description is required")]
        public string Facility_description { get; set; }
        //[Required(ErrorMessage = "IsActive is required")]
        public bool isActive { get; set; }

    }
    public enum isActive
    {
        True,
        False
    }
}
