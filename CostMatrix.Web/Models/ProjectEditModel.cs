using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CostMatrix.Web.Models
{
    public class ProjectEditModel
    {
        [HiddenInput]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ClientId { get; set; }

        [Display(Name = "Client")]
        public string ClientName { get; set; }
    }
}