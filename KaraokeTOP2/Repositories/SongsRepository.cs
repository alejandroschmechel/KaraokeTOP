using System;
using System.Collections.Generic;
using System.Linq;
using KaraokeTOP.Models;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Async;

namespace KaraokeTOP.Repositories
{
    public class SongsRepository
    {
        private SQLiteAsyncConnection dbConn;

        public string StatusMessage { get; set; }

        public SongsRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //initialize a new SQLiteConnection 
            if (dbConn == null)
            {
                var connectionFunc = new Func<SQLiteConnectionWithLock>(() =>
                    new SQLiteConnectionWithLock
                    (
                        sqlitePlatform,
                        new SQLiteConnectionString(dbPath, false)
                    ));

                dbConn = new SQLiteAsyncConnection(connectionFunc);
                dbConn.CreateTableAsync<Item>();
            }
        }

        public async Task AddNewPersonAsync(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                //insert a new person into the Person table
                result = await dbConn.InsertAsync(new Item { SongName = name });
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async Task<List<Item>> GetAllSongsAsync()
        {
            //return a list of people saved to the Person table in the database
            List<Item> songs = await dbConn.Table<Item>().ToListAsync();
            return songs;
        }

        public async Task<List<Item>> GetSongsPagged(int offset = 0)
        {
            //return a list of people saved to the Person table in the database
            List<Item> songs = dbConn.QueryAsync<Item>($"SELECT * FROM [Item] LIMIT {offset}, 15").Result;
            return songs;
        }

        public async Task<List<Item>> GetArtistsPaged(int offset = 0)
        {
            //return a list of people saved to the Person table in the database
            List<Item> songs = dbConn.QueryAsync<Item>($"SELECT Artist from [Item] group by Artist LIMIT {offset}, 50").Result;
            return songs;
        }

        public async Task<List<Item>> GetSongsFromArtist(string ArtistName)
        {
            //return a list of people saved to the Person table in the database
            List<Item> songs = dbConn.QueryAsync<Item>($"SELECT * from [Item] where Artist = ?", new String[] { ArtistName }).Result;
            return songs;
        }

        public async Task<List<Item>> GetSongsAlphabeticalPagged(int offset = 0)
        {
            //return a list of people saved to the Person table in the database
            List<Item> songs = dbConn.QueryAsync<Item>($"SELECT * FROM [Item] order by SongName ASC LIMIT {offset}, 15").Result;
            return songs;
        }

        public async Task<List<Item>> GetFromSearch(string Search)
        {
            //return a list of people saved to the Person table in the database
            string query = String.Format("SELECT * FROM [Item] Where SongName like '%{0}%' or Artist like '%{0}%'", Search);
            List<Item> songs = dbConn.QueryAsync<Item>(query).Result;
            return songs;
        }

    }
}