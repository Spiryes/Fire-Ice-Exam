using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fireiceproj.Models
{
    public class queryviewmodel
    {
       
        [Required(ErrorMessage = "What is your problem")]
        public string Nameoftheproblem { get; set; }
        [Display(Name = "Discribe your problem")]
        public string Txt { get; set; }
        [Required(ErrorMessage = "Provide your Adress")]
        [Display(Name = "Your adress")]
        public string Adress { get; set; }


        [Display(Name = "Picture of the problem")]
        public IFormFile Image { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Date of the visit")]
        public DateTime Dateofvisit { get; set; }
        [Display(Name = "Name of the technition")]
        public string Nameoftechnition { get; set; }
    }
}
