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
using Java.Lang;

namespace XamarinAndroid1
{
    class MyListViewAdapter : BaseAdapter<Person>
    {

        public List<Person> mItems;
        public Context myContext;

        public MyListViewAdapter(Context context, List<Person> items) {

            mItems = items;
            myContext = context;

        }

        public override int Count {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Person this[int position] {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null) {
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView txtName = row.FindViewById<TextView>(Resource.Id.txtName);
            txtName.Text = mItems[position].Name;

            TextView txtAge = row.FindViewById<TextView>(Resource.Id.txtAge);
            txtAge.Text = mItems[position].Age.ToString();

            TextView txtEmail = row.FindViewById<TextView>(Resource.Id.txtEmail);
            txtEmail.Text = mItems[position].Email;

            TextView txtPassword = row.FindViewById<TextView>(Resource.Id.txtPassword);
            txtPassword.Text = mItems[position].Password;

            return row;
        }
    }
}