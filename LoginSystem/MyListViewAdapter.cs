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
using RaysHotDogs.Utility;

namespace SmartDialer
{
    class MyListViewAdapter : BaseAdapter<PhotoEntry> // interface means we have to override the base methods of baseadapter
    {
        private List<PhotoEntry> mItems;
        private Context mContext;
        private Action<ImageView> mActionPicSelected;

        public MyListViewAdapter(Context context, int layout, List<PhotoEntry> items)
        {
            mItems = items;
            mContext = context;
            //mActionPicSelected = picSelected;
        }

        public override int Count // tells the listview how many rows there are 
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override PhotoEntry this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = mItems[position];

            var imageBitMap = ImageHelper.GetImageBitmapFromFilePath(item.FilePath, item.Height, item.Width);

            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.PhotoListRow, null, false);
                //inflater takes a resource and 'inflates it' and makes a view out of it
            }

            TextView txtName = row.FindViewById<TextView>(Resource.Id.txtFileName); //sets reference to the axml text            
            txtName.Text = item.FileName;

            row.FindViewById<ImageView>(Resource.Id.imgThumbnail).SetImageBitmap(imageBitMap);


            return row;

        }

    }
}