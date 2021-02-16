using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TODO.Domain.Contracts.Repositories;
using TODO.Domain.Contracts.Services;
using TODOLib.Entities;

namespace TODO.Domain.Services
{
    public class ServiceTODO : IServiceTODO
    {
        private readonly IRepositoryTODO _repositoryTODO;

        public ServiceTODO(IRepositoryTODO repositoryTODO)
        {
            _repositoryTODO = repositoryTODO;
        }

        public async Task<TODOEntity> Add(TODOEntity tODOEntity)
        {
            return await _repositoryTODO.Add(tODOEntity);
        }

        public async Task<TODOEntity> Delete(int id)
        {
            return await _repositoryTODO.Delete(id);
        }

        public async Task<List<TODOEntity>> GetAll()
        {
            return await _repositoryTODO.GetAll();
        }

        public async Task<TODOEntity> GetById(int id)
        {
            return await _repositoryTODO.GetById(id);
        }

        public async Task<TODOEntity> Update(TODOEntity tODOEntity)
        {
            return await _repositoryTODO.Update(tODOEntity);
        }
    }
}
