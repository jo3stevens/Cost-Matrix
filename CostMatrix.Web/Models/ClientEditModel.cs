using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CostMatrix.Web.Models
{
    public class ClientEditModel
    {
        [HiddenInput]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}