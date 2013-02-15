using System;
using System.Collections.Generic;
using CostMatrix.Core.Domain;

namespace CostMatrix.Core.Service
{
    public interface IClientService
    {
        void Add(string name, string createdBy, DateTime createdOn);
        void Edit(string id, string name);
        void Delete(string id);
        IEnumerable<Client> GetAll();
        Client GetById(string id);
        Client GetByProjectId(string id);
        void AddProject(string clientId, string name, string createdBy, DateTime createdOn);
        void EditProject(string id, string name);
        void DeleteProject(string id);
    }
}