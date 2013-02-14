
using MongoDB.Bson;
namespace CostMatrix.Core.Domain
{
    public class Setting
    {
        public ObjectId Id { get; set; }
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
    }
}
