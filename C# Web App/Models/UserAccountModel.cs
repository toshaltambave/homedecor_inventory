using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeDecor.Models
{
    public class UserAccount
    {   // User table in Database with fields UserID, UserName, UserPassword, AccessRights
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "Access Rights required")]
        //[StringLength(3, MinimumLength = 1)]
        //[RegularExpression("([R,W,X]+)")]
        //[Display(Description = "RWX,RW,X,W,R")]
        public string AccessRights { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public int Facility_code { get; set; }
        [ForeignKey("Facility_code")]
        public virtual FacilityModel FacilityModel1 { get; set; }
        public bool isActive { get; set; }

    }

    public enum AccessRights
    {
        RWX,
        RW,
        X,
        W,
        R
    }
}