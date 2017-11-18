using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using DataSqLite.Resources.Model;
using DataSqLite.Resources.DataHelper;
using Android.Graphics;

namespace DataSqLite
{
    [Activity(Label = "DataSqLite", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        ListView listView;
        Button add, edit, delete;
        List<Person> personSource = new List<Person>();
        Database database;
        EditText edtName, edtAge, edtEmail;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            database = new Database();
            database.createDataBase();

            listView = FindViewById<ListView>(Resource.Id.listView);
            edtName = FindViewById<EditText>(Resource.Id.edtName);
            edtAge = FindViewById<EditText>(Resource.Id.edtAge);
            edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);

            add = FindViewById<Button>(Resource.Id.btnAdd);
            edit = FindViewById<Button>(Resource.Id.btnEdit);
            delete = FindViewById<Button>(Resource.Id.btnDelete);
             
            LoadData();

            add.Click += delegate {

                Person person = new Person() { Name=edtName.Text, Age = int.Parse(edtAge.Text), Email = edtEmail.Text };
                database.insertIntoTablePerson(person);
                LoadData();
            };

            edit.Click += delegate {
                
                Person person = new Person() {ID=int.Parse(edtName.Tag.ToString()) ,Name = edtName.Text, Age = int.Parse(edtAge.Text), Email = edtEmail.Text };
                database.updateTablePerson(person);
                LoadData();
            };

            delete.Click += delegate {

                Person person = new Person() { ID = int.Parse(edtName.Tag.ToString()), Name = edtName.Text, Age = int.Parse(edtAge.Text), Email = edtEmail.Text };
                database.deleteTablePerson(person);
                LoadData();
            };

            listView.ItemClick += ListView_ItemClick;

        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            for (int i = 0; i < listView.Count; i++)
            {
                if (e.Position == i)
                {
                    listView.GetChildAt(i).SetBackgroundColor(Color.DarkGray);
                }
                else {
                    listView.GetChildAt(i).SetBackgroundColor(Color.Transparent);
                }
            }

            //Binding Data


            var txtName = FindViewById<TextView>(Resource.Id.textView1);
            var txtAge = FindViewById<TextView>(Resource.Id.textView2);
            var txtEmail = FindViewById<TextView>(Resource.Id.textView3);

            edtName.Text = txtName.Text;
            edtName.Tag = e.Id;

            edtAge.Text = txtAge.Text;

            edtEmail.Text = txtEmail.Text;


        }
        
        public void LoadData() {

            personSource = database.selectTablePerson();
            var adapater = new ListViewAdapter(this, personSource);
            listView.Adapter = adapater;
        }
    }
}

