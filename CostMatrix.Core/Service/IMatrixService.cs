using System;
using System.Collections.Generic;
using CostMatrix.Core.Domain;

namespace CostMatrix.Core.Service
{
    public interface IMatrixService
    {
        string Add(Matrix matrix);
        void Edit(Matrix matrix);
        void Delete(string id);
        void DeleteByProjectId(string id);
        IEnumerable<Matrix> GetByProjectId(string id);
        Matrix GetById(string id);
        void Clone(string id, string name, string createdBy, DateTime createdOn);
    }
}