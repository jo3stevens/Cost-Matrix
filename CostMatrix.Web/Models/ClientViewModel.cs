using System.Collections.Generic;

namespace CostMatrix.Web.Models
{
    public class ClientViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedOn { get; set; }
    }
}