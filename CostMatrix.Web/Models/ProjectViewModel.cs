
using System.Collections.Generic;
namespace CostMatrix.Web.Models
{
    public class ProjectViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<MatrixViewModel> Matrixes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}