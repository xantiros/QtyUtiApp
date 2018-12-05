using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using QtyUtiApp.Core.Models;
using SQLite;

namespace QtyUtiApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            //EditText textDate = FindViewById<EditText>(Resource.Id.editTextDate);
            //EditText textQty = FindViewById<EditText>(Resource.Id.editTextQty);
            Button btn = FindViewById<Button>(Resource.Id.btn_Add);
            btn.Click += btnOnClick;


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        private void btnOnClick(object sender, EventArgs eventArgs)
        {
            EditText textDate = FindViewById<EditText>(Resource.Id.editTextDate);
            EditText textQty = FindViewById<EditText>(Resource.Id.editTextQty);

            Gas gas = new Gas(int.Parse(textQty.Text.ToString()), DateTime.Parse(textDate.Text.ToString()));

            SQLiteDatabase db = new SQLiteDatabase();
            db.CopyDatabase2();

            string dbName = "QtyUtiDB.db";
            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

            using (var conn = new SQLiteConnection(dbPath))
            {
                //conn.CreateTable<Gas>();

                
                var count = conn.Insert(gas);

                List<Gas> gass = conn.Table<Gas>().ToList();


                //var cmd = new SQLiteCommand(conn);
                //cmd.CommandText = "select * from gas";
                //var r = cmd.ExecuteQuery<Gas>();

                //Console.Write(r);
            }
        }

    }
}

