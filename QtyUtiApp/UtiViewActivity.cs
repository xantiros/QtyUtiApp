using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QtyUtiApp.Core.Models;

namespace QtyUtiApp
{
    [Activity(Label = "UtiViewActivity")]
    public class UtiViewActivity : Activity
    {
        SQLiteDatabase db = new SQLiteDatabase();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UtiView);

            ListView listView = FindViewById<ListView>(Resource.Id.listView2);

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

        }
    }
}