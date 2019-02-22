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
using Android.Provider;

namespace SmartDialer
{
    [Activity(Label = "MainMenuActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class MainMenuActivity : Activity
    {

        private ImageButton mBtnCamera;
        private ImageButton mBtnPhotoList;
        private ImageButton mBtnMaps;
        private ImageButton mBtnSettings;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MenuView);

            FindViews();

            HandleEvents();
           
        }

        private void FindViews()
        {
            mBtnCamera = FindViewById<ImageButton>(Resource.Id.btnCamera);
            mBtnSettings = FindViewById<ImageButton>(Resource.Id.btnSettings);
            mBtnMaps = FindViewById<ImageButton>(Resource.Id.btnMaps);
            mBtnPhotoList = FindViewById<ImageButton>(Resource.Id.btnPhotoList);
        }

        private void HandleEvents()
        {
            mBtnCamera.Click += MBtnCamera_Click;
            //mBtnMaps.Click += MBtnMaps_Click;
            mBtnPhotoList.Click += MBtnPhotoList_Click;
            mBtnSettings.Click += MBtnSettings_Click;
        }

        private void MBtnSettings_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SettingsActivity));
            StartActivity(intent);
        }

        private void MBtnPhotoList_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ListActivity));
            StartActivity(intent);
        }

        //private void MBtnMaps_Click(object sender, EventArgs e)
        //{
        //    var intent = new Intent(this, typeof(MapActivity));
        //    StartActivity(intent);
        //}

        private void MBtnCamera_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CameraActivity));
            StartActivity(intent);
        }
    }
}