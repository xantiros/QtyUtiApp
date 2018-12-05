﻿using Android.App;
using QtyUtiApp.Core.Models;
using SQLite;
using System.IO;

namespace QtyUtiApp
{
    public class SQLiteDatabase
    {
        //public SQLiteConnection SQLiteConnection { get; private set; }

        //public ISQLitePlatform SQLitePlatform { get; private set; }

        public void SaveToDatabase2(Utility uti)
        {
            //using (SQLiteConnection = new SQLiteConnection(SQLitePlatform, "Data Source=./Database/QuizDB.db"))
            //{
            //    SQLiteConnection.Execute($"insert into {uti.GetType().Name} (date, quantity) values (@date, @quantity)", uti);
            //}
        }
        public void SaveToDatabase(SQLiteConnection db, Utility uti)
        {
            var s = db.Insert(uti);

            //var s = db.Insert(new Stock()
            //{
            //    Symbol = symbol
            //});
            //Console.WriteLine("{0} == {1}", s.Symbol, s.Id);
        }
        //public SQLiteAsyncConnection GetConnection()
        //{
        //    var sqliteFilename = "QtyUtiDB.db";
        //    string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
        //    var path = Path.Combine(documentsPath, sqliteFilename);
        //    var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        //    var param = new SQLiteConnectionString(path, false);
        //    var connection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, param));
        //    return connection;
        //}

        public SQLiteConnection SQLiteConnection()
        {
            var sqliteFilename = "QtyUtiDB.db";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, sqliteFilename);

            if(!File.Exists(path))
            {

            }
            //var plat = new SQLite.Net.Platform.XamarinAndroid.SqlitePlatformAndroid();
            //var conn = new 
            //var conn = new SQLiteConnection("Data Source=./Databases/QtyUtiDB.db");
            var conn = new SQLiteConnection(path);
            //conn.Insert(gas);
            return conn;
            ;
        }

        public void CopyDatabase(string dataBaseName)
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dataBaseName);

            if (!File.Exists(dbPath))
            {
                var dbAssetStream = Application.Context.Assets.Open(dataBaseName);
                var dbFileStream = new FileStream(dbPath, FileMode.OpenOrCreate);
                var buffer = new byte[1024];

                int b = buffer.Length;
                int length;

                while ((length = dbAssetStream.Read(buffer, 0, b)) > 0)
                {
                    dbFileStream.Write(buffer, 0, length);
                }

                dbFileStream.Flush();
                dbFileStream.Close();
                dbAssetStream.Close();
            }
        }

        public void CopyDatabase2()
        {
            string dbName = "QtyUtiDB.db";
            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);
            // Check if your DB has already been extracted.
            if (!File.Exists(dbPath))
            {
                using (BinaryReader br = new BinaryReader(Android.App.Application.Context.Assets.Open(dbName)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
            }
        }
        public int AddNewGas(SQLiteConnection conn, Gas gas)
        {
            return conn.Insert(gas);
        }

    }
}