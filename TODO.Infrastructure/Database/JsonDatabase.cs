using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Domain.Contracts.Database;
using TODOLib.Entities;
using TODOLib.Handlers.JSON;

namespace TODO.Infrastructure.Database
{
    public class JsonDatabase : IDatabase
    {
        public async Task<TODOEntity> Add(TODOEntity tODOEntity)
        {
            var tODOList = LoadDatabase();
            tODOEntity.Id = ReturnNextId(tODOList);
            tODOList.Add(tODOEntity);
            SaveDatabase(tODOList);
            return tODOEntity;
        }

        public async Task<TODOEntity> Delete(int id)
        {
            var tODOList = LoadDatabase();
            var tODOToDelete = tODOList.Where(w => w.Id == id).FirstOrDefault();
            if (tODOToDelete != null)
            {
                tODOList.Remove(tODOToDelete);
            }
            SaveDatabase(tODOList);
            return tODOToDelete;
        }

        public async Task<List<TODOEntity>> GetAll()
        {
            return LoadDatabase();
        }

        public async Task<TODOEntity> GetById(int id)
        {
            var tODOList = LoadDatabase();
            return tODOList.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<TODOEntity> Update(TODOEntity tODOEntity)
        {
            var tODOList = LoadDatabase();
            foreach (var tODO in tODOList)
            {
                if (tODOEntity.Id == tODO.Id)
                {
                    tODO.Update(tODOEntity);
                    SaveDatabase(tODOList);
                    return tODOEntity;
                }
            }
            return null;
        }

        private List<TODOEntity> LoadDatabase()
        {
            return TODOJASONHandler.ConverJSONToTODOList(JSONHandler.LoadJson());
        }

        private void SaveDatabase(List<TODOEntity> tODOList)
        {
            if (tODOList.Any())
            {
                JSONHandler.SaveJson(TODOJASONHandler.ConverTODOListToJSON(tODOList));
            } else
            {
                JSONHandler.SaveJson("");
            }
            
        }

        private int ReturnNextId(List<TODOEntity> tODOList)
        {
            if (tODOList.Any())
            {
                return (tODOList.Max(x => x.Id) + 1);
            } else
            {
                return 1;
            }
            
        }
    }
}
