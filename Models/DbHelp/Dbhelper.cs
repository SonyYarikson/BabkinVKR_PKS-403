using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbHelp
{
    using Models.DataContext;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// class for initializing database with data
    /// </summary>
    public static class DbInitializer
    {
        private static string[] _opt = { };
        private static DashBoardDataContext _dashBoardDataContext = new DashBoardContextDesignTimeFactory().CreateDbContext(_opt);
        private static readonly string _path = "C:\\Users\\Yaros\\Desktop\\BabkinsDashBoard-master\\Models\\DbHelp\\Data\\";

        /// <summary>
        /// provides DbSets with data from json files.
        /// </summary>
        /// <returns>0 if everything is okay, 1 if some data deserialized wrong</returns>
        public static int InitDatabase()
        {
            if (!_dashBoardDataContext.UserRoles.Any())
            {
                string path = Path.Combine(_path, "UserRoles.json");
                string json = File.ReadAllText(path);
                var cities = JsonSerializer.Deserialize<List<UserRole>>(json);

                if (cities == null)
                {
                    return 1;
                }
                
                _dashBoardDataContext.UserRoles.AddRange(cities);
            }

            if (!_dashBoardDataContext.Users.Any())
            {
                string path = Path.Combine(_path, "Users.json");
                string json = File.ReadAllText(path);
                var categories = JsonSerializer.Deserialize<List<User>>(json);

                if (categories == null)
                {
                    return 1;
                }

                _dashBoardDataContext.Users.AddRange(categories);
            }

            if (!_dashBoardDataContext.Boards.Any())
            {
                string path = Path.Combine(_path, "Boards.json");
                string json = File.ReadAllText(path);
                var restaraunts = JsonSerializer.Deserialize<List<Board>>(json);

                if (restaraunts == null)
                {
                    return 1;
                }

                _dashBoardDataContext.Boards.AddRange(restaraunts);
            }

            if (!_dashBoardDataContext.Cards.Any())
            {
                string path = Path.Combine(_path, "Cards.json");
                string json = File.ReadAllText(path);
                var restarauntsInCities = JsonSerializer.Deserialize<List<Card>>(json);

                if (restarauntsInCities == null)
                {
                    return 1;
                }

                _dashBoardDataContext.Cards.AddRange(restarauntsInCities);
            }

            if (!_dashBoardDataContext.Rows.Any())
            {
                string path = Path.Combine(_path, "Rows.json");
                string json = File.ReadAllText(path);
                var options = new JsonSerializerOptions
                {
                    Converters =
                {
                    new ByteArrayConverter()
                }
                };
                var positions = JsonSerializer.Deserialize<List<Row>>(json);

                if (positions == null)
                {
                    return 1;
                }

                _dashBoardDataContext.Rows.AddRange(positions);
            }
            
            _dashBoardDataContext.SaveChanges();
            return 0;
        }
        public class ByteArrayConverter : JsonConverter<byte[]>
        {
            public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                string base64 = reader.GetString();
                return Convert.FromBase64String(base64);
            }

            public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(Convert.ToBase64String(value));
            }
        }
    }
}

