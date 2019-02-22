using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;
using Android.Content;

namespace SmartDialer
{
    [Activity(Label = "SmartDialer", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
    public class LoginActivity : Activity
    {

        private Button mBtnSignUp;
        private Button mBtnSignIn;
        private ProgressBar mProgressBar;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LoginView);

            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            mBtnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);

            mBtnSignIn.Click += MBtnSignIn_Click;

            mBtnSignUp.Click += (object sender, EventArgs args) =>
            {
                // when button is clicked, dialog box will pop up            
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_SignUp signUpDialog = new dialog_SignUp();
                signUpDialog.Show(transaction, "dialog fragment");

                signUpDialog.mOnSignUpComplete += SignUpDialog_mOnSignUpComplete; // subscribes signUpDialog to the event after broadcast


            };
        }

        private void MBtnSignIn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainMenuActivity));
            StartActivity(intent);
        }

        private void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e) //method gets executed when event is fired 
        {

            mProgressBar.Visibility = Android.Views.ViewStates.Visible; // main UI thread makes the progress bar visible when called

            Thread thread = new Thread(ActLikeARequest); //replacement for a normal web client request, call a request function (usually)

            thread.Start();
            
        }

        private void ActLikeARequest()
        {
            Thread.Sleep(3000);

            RunOnUiThread(() => { mProgressBar.Visibility = Android.Views.ViewStates.Invisible; });
        }
    }
}

