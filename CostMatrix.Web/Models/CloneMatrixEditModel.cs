using System.ComponentModel.DataAnnotations;

namespace CostMatrix.Web.Models
{
    public class CloneMatrixEditModel
    {
        public string Id { get; set; }
        public string ClientId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}