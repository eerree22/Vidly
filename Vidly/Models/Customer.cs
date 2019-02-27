using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "名稱")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
       
        public MembershipType MembershipType { get; set; }

        [Display(Name = "會員類別")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "生日")]
        public DateTime? Birthdate { get; set; }
    }
}