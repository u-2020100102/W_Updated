
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumble.Model
{
    public class Database
    {
        private SQLiteAsyncConnection projectDatabase;
        private string dbName = "users.db3";


        public Database()
        {

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);
            projectDatabase = new SQLiteAsyncConnection(dbPath);
            projectDatabase.CreateTableAsync<User>(CreateFlags.AllImplicit | CreateFlags.AutoIncPK).GetAwaiter().GetResult();

        }

        public async Task<User> FindUser(string username, string password)
        {
            var user = await projectDatabase.Table<User>().Where(u => u.Password == password).FirstOrDefaultAsync();
            return user;
        }

        public async Task AddUser(User user)
        {
            await projectDatabase.InsertAsync(user);

        }

        public async Task<User> GetUserByID(int Id)
        {

            var user = await projectDatabase.Table<User>().Where(c => c.Id == Id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> GetChildByID(int Id)
        {

            var user = await projectDatabase.Table<User>().Where(c => c.IdentityNumber == Id).FirstOrDefaultAsync();
            return user;
        }



        public async Task Update(User user)
        {
            await projectDatabase.UpdateAsync(user);
        }
    }
}
