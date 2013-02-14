using System;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CostMatrix.Core.Domain
{
    public class Matrix
    {
        public ObjectId Id { get; set; }
        public ObjectId ProjectId { get; set; }
        public string Name { get; set; }
        public Setting Settings { get; set; }
        public IEnumerable<Section> Sections { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public class Section
        {
            public string Name { get; set; }
            public IEnumerable<Item> Items { get; set; }

            public class Item
            {
                public string Description { get; set; }
                public string AdditionalInformation { get; set; }
                public decimal FrontEnd { get; set; }
                public decimal BackEnd { get; set; }
                public decimal Design { get; set; }
                public decimal ArtDirector { get; set; }
                public decimal Producer { get; set; }
                public decimal AccountDirector { get; set; }
                public decimal ServerManagement { get; set; }
                public decimal Seo { get; set; }
                public decimal Copyrighter { get; set; }
                public decimal Testing { get; set; }
                public decimal ProjectManagement { get; set; }
                public decimal Other { get; set; }
            }
        }
    }
}
