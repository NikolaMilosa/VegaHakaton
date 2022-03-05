using Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Services.DatabasePopulator
{
    public class DatabasePopulatorService
    {
        public void Populate(AppDbContext context)
        {
            var content = File.ReadAllText("citaonice.json");
            var faculties = JsonConvert.DeserializeObject<List<Faculty>>(content);
            context.AddRange(faculties);
            context.SaveChanges();
        }
    }
}
