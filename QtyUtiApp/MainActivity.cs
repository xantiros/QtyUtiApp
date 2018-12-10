using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
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
        SQLiteDatabase db = new SQLiteDatabase();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;


            Button btn = FindViewById<Button>(Resource.Id.btn_Add);
            btn.Click += btnOnClick;

            ListView listView = FindViewById<ListView>(Resource.Id.listView);

            db.CopyDatabase(); //kopiuje baze na telefon z apki

            List<Gas> gass = null;
            List<string> abc = null;
            try
            {
                using (var conn = db.SQLiteConnection)
                {
                    gass = conn.Table<Gas>().ToList();
                    abc = gass.ConvertAll(x => x.ToString());
                }

                ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, abc);
                listView.Adapter = arrayAdapter;
            }
            catch (Exception)
            {
            }

            Button btnNewPage = FindViewById<Button>(Resource.Id.btn_NewPage);
            btnNewPage.Click += btnNewPageClick;


        }

        private void btnNewPageClick(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.UtiView);
            Intent intent = new Intent(this, typeof(UtiViewActivity));
            StartActivity(intent);
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
            EditText textQty = FindViewById<EditText>(Resource.Id.editTextGasQty);

            Gas gas = new Gas(int.Parse(textQty.Text.ToString()), DateTime.Parse(textDate.Text.ToString()));

            string dbName = "QtyUtiDB.db";
            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

            var count = db.AddNewGas2(db, gas);
            List<string> allgass = db.GetAllGass2(db).ConvertAll(x => x.ToString());

            ListView listView = FindViewById<ListView>(Resource.Id.listView);
            ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, allgass);
            listView.Adapter = arrayAdapter;

        }

    }
}

