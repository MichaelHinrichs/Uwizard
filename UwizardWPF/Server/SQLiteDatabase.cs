using System;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.Generic;

namespace UwizardWPF.Server
{
    public class SQLiteDatabase : ISQLiteDatabase
    {
        private readonly SQLiteConnection _dbConnection;
        public SQLiteDatabase()
        {
            _dbConnection = new SQLiteConnection(new SQLitePlatformGeneric(), "./Server/Uwizard.db", SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, false);
        }
        public Task Do(Action<SQLiteConnection> action)
        {
            throw new NotImplementedException();
        }

        public void DoSync(Action<SQLiteConnection> action)
        {
            try
            {
                _dbConnection.BeginTransaction();
                action.Invoke(_dbConnection);
                _dbConnection.Commit();
            }
            catch (SQLiteException)
            {
                _dbConnection.Rollback();
            }
            
        }

        public Task<TResult> Do<TResult>(Func<SQLiteConnection, TResult> func)
        {
            throw new NotImplementedException();
        }

        public TResult DoSync<TResult>(Func<SQLiteConnection, TResult> func)
        {
            throw new NotImplementedException();
        }
    }
}
