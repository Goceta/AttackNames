using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackNames.Metadata
{
    class LocalDatabase
    {
        String DatabaseFileLocation;

        List<Attack> Attacks;

        public LocalDatabase()
        {
            DatabaseFileLocation = @"d:\AttackDatabase.json";
            Attacks = new List<Attack>();

            Attack Hadoken = new Attack()
            {
                Name = "Hadoken",
                LocalLocation = "Somewhere on this PC",
                ReleaseDate = DateTime.Parse("1991-07-05"),
                Media = MediaType.Game
            };

            Attack IronReaver = new Attack()
            {
                Name = "Iron Reaver Soul Stealer",
                LocalLocation = "Somewhere on this PC",
                ReleaseDate = DateTime.Parse("1995-01-01"),
                Media = MediaType.Anime
            };

            Attacks.Add(Hadoken);
            Attacks.Add(IronReaver);
        }

        public void LoadDatabase()
        {

        }
        public void SaveDatabase()
        {
            var serializedDatabase = JsonConvert.SerializeObject(Attacks, Formatting.Indented);

            using (StreamWriter file = File.CreateText(DatabaseFileLocation))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Attacks);
            }
        }
    }
}
