using Android.App;
using Android.Widget;
using Android.OS;

namespace LoginSystem
{
    [Activity(Label = "LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        Button btnSignUp;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            btnSignUp.Click += BtnSignUp_Click;

        }

        private void BtnSignUp_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_SignUp dialog = new dialog_SignUp();
            dialog.Show(transaction, "Signup Dialog");
        }
    }
}

