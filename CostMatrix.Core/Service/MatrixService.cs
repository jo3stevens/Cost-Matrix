using System;
using System.Collections.Generic;
using CostMatrix.Core.Domain;
using CostMatrix.Core.Helpers;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace CostMatrix.Core.Service
{
    public class MatrixService : IMatrixService
    {
        private readonly MongoHelper<Matrix> _db;

        public MatrixService()
        {
            _db = new MongoHelper<Matrix>();
        }

        public string Add(Matrix matrix)
        {
            _db.Collection.Insert(matrix);
            return matrix.Id.ToString();
        }

        public void Edit(Matrix matrix)
        {
            _db.Collection.Save(matrix);
        }

        public void Delete(string id)
        {
            _db.Collection.Remove(Query.EQ("_id", ObjectId.Parse(id)));
        }

        public void DeleteByProjectId(string id)
        {
            _db.Collection.Remove(Query.EQ("ProjectId", ObjectId.Parse(id)));
        }

        public IEnumerable<Matrix> GetByProjectId(string id)
        {
            return _db.Collection.Find(Query.EQ("ProjectId", ObjectId.Parse(id))).SetSortOrder("Name");
        }

        public Matrix GetById(string id)
        {
            return _db.Collection.FindOneById(ObjectId.Parse(id));
        }

        public void Clone(string id, string name, string createdBy, DateTime createdOn)
        {
            var matrix = GetById(id);
            matrix.Id = ObjectId.GenerateNewId();
            matrix.Name = name;
            matrix.CreatedBy = createdBy;
            matrix.CreatedOn = createdOn;

            _db.Collection.Insert(matrix);
        }
    }
}
