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
using Android.Graphics;
using Java.IO;


namespace SmartDialer
{
    [Activity(Label = "ListActivity")]
    public class ListActivity : Activity
    {
        private BaseAdapter<PhotoEntry> mAdapter;
        private List<PhotoEntry> mItems;
        private ListView mListView;
        private ImageView mSelectedPic; //keeps track of current picture

        private List<String> f;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListView);

            mListView = FindViewById<ListView>(Resource.Id.myListView);
            mItems = new List<PhotoEntry>();




            // need code here to access the phones internal storage and add the pictures in local directory as
            // PhotoEntry objects and then pass them through the adapter




            var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).AbsolutePath + "/Photo";            

            File f = new File(path);
            File[] files = f.ListFiles();
            
            foreach(string file in files)
            {
                Bitmap bitmap = BitmapFactory.DecodeFile(file);
                PhotoEntry photoEntry = new PhotoEntry();

                Uri uri = new Uri(file);
                if (uri.IsFile)
                {
                    photoEntry.FileName = System.IO.Path.GetFileName(uri.LocalPath);
                }

                photoEntry.FilePath = file;
                photoEntry.Height = bitmap.Height;
                photoEntry.Width = bitmap.Width;
                mItems.Add(photoEntry);
            }



            mAdapter = new MyListViewAdapter(this, Resource.Layout.PhotoRowView, mItems);
            mListView.Adapter = mAdapter;  

        }
    }
}