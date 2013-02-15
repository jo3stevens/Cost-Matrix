using CostMatrix.Core.Domain;
using CostMatrix.Core.Helpers;
using System.Linq;

namespace CostMatrix.Core.Service
{
    public class SettingService : ISettingService
    {
        private readonly MongoHelper<Setting> _db;

        public SettingService()
        {
            _db = new MongoHelper<Setting>();
        }

        public Setting Get()
        {
            return _db.Collection.FindAll().FirstOrDefault();
        }

        public void Save(Setting setting)
        {
            _db.Collection.RemoveAll();
            _db.Collection.Insert(setting);
        }
    }
}
