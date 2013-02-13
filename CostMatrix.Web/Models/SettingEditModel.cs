
using System.ComponentModel.DataAnnotations;
namespace CostMatrix.Web.Models
{
    public class SettingEditModel
    {
        [Display(Name = "Front End")]
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal FrontEnd { get; set; }

        [Display(Name = "Back End")]
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal BackEnd { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Design { get; set; }

        [Display(Name = "Art Director")]
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal ArtDirector { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Producer { get; set; }

        [Display(Name = "Account Director")]
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal AccountDirector { get; set; }
        
        [Display(Name = "Server Management")]
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal ServerManagement { get; set; }

        [Display(Name = "SEO")]
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Seo { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Copyrighter { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Testing { get; set; }

        [Display(Name = "Project Management")]
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal ProjectManagement { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Other { get; set; }
    }
}