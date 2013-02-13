using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace CostMatrix.Core.Domain
{
    public class Client
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
