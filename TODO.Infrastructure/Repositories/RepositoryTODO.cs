using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TODO.Domain.Contracts.Database;
using TODO.Domain.Contracts.Repositories;
using TODOLib.Entities;

namespace TODO.Infrastructure.Repositories
{
    public class RepositoryTODO : IRepositoryTODO
    {
        private readonly IDatabase _database;

        public RepositoryTODO(IDatabase database)
        {
            _database = database;
        }

        public async Task<TODOEntity> Add(TODOEntity tODOEntity)
        {
            tODOEntity.CreatedAt = DateTime.Now;
            return await _database.Add(tODOEntity);
        }

        public async Task<TODOEntity> Delete(int id)
        {
            return await _database.Delete(id);
        }

        public async Task<List<TODOEntity>> GetAll()
        {
            return await _database.GetAll();
        }

        public async Task<TODOEntity> GetById(int id)
        {
            return await _database.GetById(id);
        }

        public async Task<TODOEntity> Update(TODOEntity tODOEntity)
        {
            tODOEntity.UpdatedAt = DateTime.Now;
            return await _database.Update(tODOEntity);
        }
    }
}
