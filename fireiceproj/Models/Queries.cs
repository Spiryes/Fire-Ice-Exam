using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fireiceproj.Models
{
    public class Queries
    {
        [Key]// обявява се че Idquer ще бъде първичен ключ за базата данни.
        // декларират се променливи които ще бъдат полетата на нашата база данни.
        public int Idquer { get; set; }
         [Required(ErrorMessage = "What is your problem")]
        public string Nameoftheproblem { get; set; }
        [Display(Name = "Discribe your problem")]
        public string Txt { get; set; }
        [Required(ErrorMessage = "Provide your Adress")]
        [Display(Name = "Your adress")]
        public string Adress { get; set; }

      
        [Display(Name = "Picture of the problem")]
        public string Image { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Date of the visit")]
        public DateTime Dateofvisit { get; set; }
        [Display(Name = "Name of the technition")]
        public string Nameoftechnition { get; set; }
    }
}
