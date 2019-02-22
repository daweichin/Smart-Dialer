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
using Java.IO;
using Android.Provider;
using Android.Graphics;
using RaysHotDogs.Utility;

namespace SmartDialer
{
    [Activity(Label = "CameraActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class CameraActivity : Activity
    {
        private ImageView mPhoto;
        private Button mbtnTakePhoto;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CameraView);

            mPhoto = FindViewById<ImageView>(Resource.Id.imageView1);
            mbtnTakePhoto = FindViewById<Button>(Resource.Id.btnTakePhoto);

            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "Photo");

            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }

            mbtnTakePhoto.Click += MbtnTakePhoto_Click;

            
        }



        private void MbtnTakePhoto_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new File(imageDirectory, String.Format("Testphoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));
            StartActivityForResult(intent, 0);
        }

        //protected void onActivityResult(int requestCode, int resultCode, Intent data)
        //{
        //    if (requestCode == REQUEST_IMAGE_CAPTURE && resultCode == RESULT_OK)
        //    {
        //        Bundle extras = data.getExtras();
        //        Bitmap imageBitmap = (Bitmap)extras.get("data");
        //        mImageView.setImageBitmap(imageBitmap);
        //    }
        //}

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            int height = mPhoto.Height;
            int width = mPhoto.Width;
            imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

            if(imageBitmap != null)
            {
                mPhoto.SetImageBitmap(imageBitmap);
                imageBitmap = null;
            }

            //required to avoid memory leaks
            GC.Collect();
        }
    }
}