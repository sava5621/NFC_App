using NFC_App.Model;
using SQLite;

namespace NFC_App.Services
{
    public class LocalDBServices
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "UserToken.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<UserRefreshToken>();
        }

        public static async Task AddToken(UserRefreshToken token)
        {
            await Init();
            var id = await db.InsertAsync(token);
        }

        public static async Task RemoveToken()
        {
            await Init();
            await db.DeleteAllAsync<UserRefreshToken>();
        }

        public static async Task<UserRefreshToken> GetToken()
        {
            await Init();
            if (await db.Table<UserRefreshToken>().CountAsync() != 0)
            {
                UserRefreshToken Token = await db.Table<UserRefreshToken>().FirstAsync();
                return Token;
            }
            else
            {
                return null;
            }
        }
    }
}
