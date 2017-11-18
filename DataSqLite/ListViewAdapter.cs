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
using DataSqLite.Resources.Model;
using Java.Lang;

namespace DataSqLite
{
    public class ViewHolder : Java.Lang.Object {

        public TextView Name { get; set; }
        public TextView Age { get; set; }
        public TextView Email { get; set; }
    }

     public class ListViewAdapter : BaseAdapter
    {
        Activity activity;
        List<Person> personList;

        public ListViewAdapter(Activity activity, List<Person> personList) {

            this.activity = activity;
            this.personList = personList;

        }

        public override int Count {
            get{ return personList.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return personList[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view_DataTemplate, parent, false);

            var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtAge = view.FindViewById<TextView>(Resource.Id.textView2);
            var txtEmail = view.FindViewById<TextView>(Resource.Id.textView3);

            txtName.Text = personList[position].Name;
            txtAge.Text = personList[position].Age.ToString();
            txtEmail.Text = personList[position].Email;

            return view;
        }

    }
}