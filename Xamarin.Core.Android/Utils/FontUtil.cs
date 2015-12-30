using System;
using Android.Graphics;
using Android.Content;
using Java.Util;

namespace Xamarin.Core.Android
{
    public static class FontUtil
    {
        private static readonly Hashtable FontCache = new Hashtable();

        public static Typeface LoadFont(Context context, string fontPath) {
            Typeface tf = FontCache.Get(fontPath) as Typeface;
            if (tf == null) {
                try {
                    tf = Typeface.CreateFromAsset(context.Assets, fontPath);
                } catch (Exception e) {
                    Console.WriteLine(e.StackTrace);
                    return Typeface.DefaultFromStyle(TypefaceStyle.Normal);
                }
                FontCache.Put(fontPath, tf);
            }
            return tf;
        }
    }
}

