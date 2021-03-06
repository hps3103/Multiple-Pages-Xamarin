﻿using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MultiplePages
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText UserNameET, PasswordET;
        Button LogInBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            UserNameET = (EditText)FindViewById(Resource.Id.EtUserName);
            PasswordET = (EditText)FindViewById(Resource.Id.EtPassword);
            LogInBtn = (Button)FindViewById(Resource.Id.BtnLogin);

            LogInBtn.Click += delegate
            {
                if (UserNameET.Text == "" || PasswordET.Text == "")
                {
                    Toast.MakeText(this, "Please enter Username and Password " , ToastLength.Long).Show();
                }
                else if (UserNameET.Text.Equals("admin") && PasswordET.Text.Equals("Passw0rd!@"))
                {
                    Intent intent = new Intent(this, typeof(Page2Activity));
                    StartActivity(intent);                  // Need to start the activity to go to another Page
                    // To Connect Page 2 .cs file with it. and the layout will be connectefd there
                }
                else
                {
                    Toast.MakeText(this, "Your user name or password does not match ", ToastLength.Long).Show();
                }
            };
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
	}
}

