using CostMatrix.Core.Domain;
using CostMatrix.Core.Helpers;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;

namespace CostMatrix.Core.Service
{
    public class ClientService : IClientService
    {
        private readonly MongoHelper<Client> _db;

        public ClientService()
        {
            _db = new MongoHelper<Client>();
        }

        public void Add(string name, string createdBy, DateTime createdOn)
        {
            var client = new Client {Name = name, Projects = new List<Project>(), CreatedBy = createdBy, CreatedOn = createdOn};
            _db.Collection.Save(client);
        }

        public void Edit(string id, string name)
        {
            _db.Collection.Update(Query.EQ("_id", ObjectId.Parse(id)), Update.Set("Name", name));
        }

        public void Delete(string id)
        {
            _db.Collection.Remove(Query.EQ("_id", ObjectId.Parse(id)));
        }

        public IEnumerable<Client> GetAll()
        {
            return _db.Collection.FindAll().SetSortOrder("Name");
        }

        public Client GetById(string id)
        {
            return _db.Collection.FindOne(Query.EQ("_id", ObjectId.Parse(id)));
        }
        
        public Client GetByProjectId(string id)
        {
            var client = _db.Collection.FindOne(Query.EQ("Projects._id", ObjectId.Parse(id)));
            client.Projects.RemoveAll(p => p.Id != ObjectId.Parse(id));
            return client;
        }

        public void AddProject(string clientId, string name, string createdBy, DateTime createdOn)
        {
            var project = new Project { Id = ObjectId.GenerateNewId(), Name = name, CreatedBy = createdBy, CreatedOn = createdOn };
            _db.Collection.Update(Query.EQ("_id", ObjectId.Parse(clientId)), Update.PushWrapped("Projects", project));
        }

        public void EditProject(string id, string name)
        {
            _db.Collection.Update(Query.EQ("Projects._id", ObjectId.Parse(id)), Update.Set("Projects.$.Name", name));
        }

        public void DeleteProject(string id)
        {
            _db.Collection.Update(Query.EQ("Projects._id", ObjectId.Parse(id)), Update.Pull("Projects", Query.EQ("_id", ObjectId.Parse(id))));
        }
    }
}
