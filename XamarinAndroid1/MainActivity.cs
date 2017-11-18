using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace XamarinAndroid1
{
    [Activity(Label = "First App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public List<Person> list;
        public ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            listView = FindViewById<ListView>(Resource.Id.listView1);

            list = new List<Person>() {

                new Person(){ Name ="Hussam", Age= 23, Email="Hussam7102@gmail.com", Password="abc123" },
                new Person(){ Name ="Haseeb", Age= 26, Email="Haseeb123@gmail.com", Password="admin" },
                new Person(){ Name ="Usman", Age= 18, Email="UsmanTanveer@gmail.com", Password="admin" }
            };


            MyListViewAdapter adapter = new MyListViewAdapter(this,list);

            listView.Adapter = adapter;
            
        }
    }
}

