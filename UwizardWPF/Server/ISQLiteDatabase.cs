using System;
using System.Threading.Tasks;
using SQLite.Net;

namespace UwizardWPF.Server
{
    public interface ISQLiteDatabase
    {
        Task Do(Action<SQLiteConnection> action);
        void DoSync(Action<SQLiteConnection> action);
        Task<TResult> Do<TResult>(Func<SQLiteConnection, TResult> func);
        TResult DoSync<TResult>(Func<SQLiteConnection, TResult> func);
    }
}
