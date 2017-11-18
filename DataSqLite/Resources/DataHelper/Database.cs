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
using SQLite;
using DataSqLite.Resources.Model;

namespace DataSqLite.Resources.DataHelper
{
    public class Database
    {

        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool createDataBase() {

            try {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder,"data.db"))) {

                    connection.CreateTable<Person>();

                    return true;
                }
                
            }
            catch (SQLiteException ex) {
                Android.Util.Log.Info("SQLite Exception",ex.Message);
                return false;
            }
        }

        public bool insertIntoTablePerson(Person person) {

            try
            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "data.db")))
                {

                    connection.Insert(person);

                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLite Exception", ex.Message);
                return false;
            }

        }

        public List<Person> selectTablePerson() {

            try
            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "data.db")))
                {

                    return connection.Table<Person>().ToList();
                }

            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLite Exception", ex.Message);
                return null;
            }

        }

        public bool updateTablePerson(Person person)
        {

            try
            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "data.db")))
                {

                    connection.Query<Person>("UPDATE Person set Name=?, Age=?, Email=? WHERE ID=?",person.Name,person.Age,person.Email,person.ID);

                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLite Exception", ex.Message);
                return false;
            }

        }

        public bool deleteTablePerson(Person person)
        {

            try
            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "data.db")))
                {

                    connection.Delete(person);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLite Exception", ex.Message);
                return false;
            }

        }

        public bool selectQueryTablePerson(int id)
        {

            try
            {

                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "data.db")))
                {

                    connection.Query<Person>("SELECT * FROM Person WHERE ID = ?", id);

                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                Android.Util.Log.Info("SQLite Exception", ex.Message);
                return false;
            }

        }

    }

}