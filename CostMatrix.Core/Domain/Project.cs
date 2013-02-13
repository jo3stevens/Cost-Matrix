using MongoDB.Bson;
using System;

namespace CostMatrix.Core.Domain
{
    public class Project
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
