﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TODOLib.Entities;

namespace TODO.Domain.Contracts.Database
{
    public interface IDatabase
    {
        Task<List<TODOEntity>> GetAll();
        Task<TODOEntity> GetById(int id);
        Task<TODOEntity> Add(TODOEntity tODOEntity);
        Task<TODOEntity> Update(TODOEntity tODOEntity);
        Task<TODOEntity> Delete(int id);
    }
}
