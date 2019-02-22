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

namespace SmartDialer
{
    class PhotoEntry
    {
        public byte[] Image { get; set; }
        public string FileName { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string FilePath { get; set; }
    }
}