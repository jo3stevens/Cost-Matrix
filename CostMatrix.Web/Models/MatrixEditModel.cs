using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CostMatrix.Web.Models
{
    public class MatrixEditModel
    {
        public string ClientName { get; set; }

        public SettingEditModel Settings { get; set; }

        public string ProjectId { get; set; }

        public string MatrixId { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<MatrixSection> Sections { get; set; }

        public decimal FrontEndTotal { get; set; }
        public decimal BackEndTotal { get; set; }
        public decimal DesignTotal { get; set; }
        public decimal ArtDirectorTotal { get; set; }
        public decimal ProducerTotal { get; set; }
        public decimal AccountDirectorTotal { get; set; }
        public decimal ServerManagementTotal { get; set; }
        public decimal SeoTotal { get; set; }
        public decimal CopyrighterTotal { get; set; }
        public decimal OtherTotal { get; set; }
        public decimal TestingTotal { get; set; }
        public decimal ProjectManagementTotal { get; set; }

        public decimal Total { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }

    public class MatrixSection
    {
        public Guid UniqueId { get; set; }
    
        public string Name { get; set; }
        public IList<MatrixSectionItem> Items { get; set; }

        public decimal FrontEndTotal { get; set; }
        public decimal BackEndTotal { get; set; }
        public decimal DesignTotal { get; set; }
        public decimal ArtDirectorTotal { get; set; }
        public decimal ProducerTotal { get; set; }
        public decimal AccountDirectorTotal { get; set; }
        public decimal ServerManagementTotal { get; set; }
        public decimal SeoTotal { get; set; }
        public decimal CopyrighterTotal { get; set; }
        public decimal OtherTotal { get; set; }
        public decimal TestingTotal { get; set; }
        public decimal ProjectManagementTotal { get; set; }

        public decimal Total { get; set; }
    }

    public class MatrixSectionItem
    {
        public Guid UniqueId { get; set; }

        [Required]
        public string Description { get; set; }
    
        [Display(Name = "Front End")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal FrontEnd { get; set; }

        [Display(Name = "Back End")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal BackEnd { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Design { get; set; }

        [Display(Name = "Art Director")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal ArtDirector { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Producer { get; set; }

        [Display(Name = "Account Director")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal AccountDirector { get; set; }

        [Display(Name = "Server Management")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal ServerManagement { get; set; }

        [Display(Name = "SEO")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Seo { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Copyrighter { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Testing { get; set; }

        [Display(Name = "Project Management")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal ProjectManagement { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field is invalid.")]
        public decimal Other { get; set; }

        public decimal Total { get; set; }

        public bool HasMore { get; set; }
    }
}