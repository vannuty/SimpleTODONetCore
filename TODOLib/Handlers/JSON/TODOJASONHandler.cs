using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TODOLib.Entities;

namespace TODOLib.Handlers.JSON
{
    public static class TODOJASONHandler
    {
        public static string ConverTODOListToJSON(List<TODOEntity> tODOList)
        {
            return JsonSerializer.Serialize(tODOList);
        }

        public static List<TODOEntity> ConverJSONToTODOList(string json)
        {
            List<TODOEntity> tODOEntities = new List<TODOEntity>();
            if (json != "")
            {
                tODOEntities = JsonSerializer.Deserialize<List<TODOEntity>>(json);
            }
            return tODOEntities;
        }
    }
}
