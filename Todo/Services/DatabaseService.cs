using System;
using System.IO;
using SQLite;
namespace Todo
{
    //doesn't stand on its own, abstract to keep from instantiation
    public abstract class DatabaseService
    {
        //only need one connection
        public static SQLiteConnection Connection = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "data.db"));
       
        public static void Initialize()
        {
            Connection.CreateTable<Todo>();
        }
    }
}
