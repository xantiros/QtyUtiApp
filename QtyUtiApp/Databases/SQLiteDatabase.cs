using QtyUtiApp.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace QtyUtiApp
{
    public class SQLiteDatabase
    {
        public SQLiteConnection SQLiteConnection { get; private set; }
        public string DBName { get; private set; }
        public string DBPath { get; private set; }

        public SQLiteDatabase()
        {
            DBName = "QtyUtiDB.db";
            DBPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), DBName);
            SQLiteConnection = new SQLiteConnection(DBPath);
        }

        //https://stackoverflow.com/questions/18715613/use-a-local-database-in-xamarin
        public void CopyDatabase()
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
        public int AddNewGas2(string dbPath, Gas gas)
        {
            using (var conn = new SQLiteConnection(dbPath)) //przy insercie tylko to działa
            {
                return conn.Insert(gas);
            }
                
        }
        public List<Gas> GetAllGass(SQLiteConnection conn)
        {
            return conn.Table<Gas>().ToList();
        }
    }
}