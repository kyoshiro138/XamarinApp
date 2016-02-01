using System;
using Android.Graphics;
using Android.Content;
using Java.Util;

namespace Xamarin.Core.Android
{
    public static class FontUtil
    {
        public const string FontRobotoRegular = "sans-serif";
        public const string FontRobotoLight = "sans-serif-light";
        public const string FontRobotoMedium = "sans-serif-medium";
        public const string FontRobotoThin = "sans-serif-thin";
        public const string FontRobotoCondensedRegular = "sans-serif-condensed";
        public const string FontRobotoCondensedLight = "sans-serif-condensed-light";

        private static readonly Hashtable FontCache = new Hashtable();

        public static Typeface LoadFont(Context context, string fontPath)
        {
            Typeface tf = FontCache.Get(fontPath) as Typeface;
            if (tf == null)
            {
                try
                {
                    tf = Typeface.CreateFromAsset(context.Assets, fontPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return Typeface.DefaultFromStyle(TypefaceStyle.Normal);
                }
                FontCache.Put(fontPath, tf);
            }
            return tf;
        }

        public static Typeface LoadSystemFont(string fontFamily, TypefaceStyle fontStyle = TypefaceStyle.Normal)
        {
            Typeface tf = FontCache.Get(fontFamily + fontStyle) as Typeface;
            if (tf == null)
            {
                try
                {
                    tf = Typeface.Create(fontFamily, fontStyle);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return Typeface.DefaultFromStyle(fontStyle);
                }
                FontCache.Put(fontFamily + fontStyle, tf);
            }
            return tf;
        }
    }
}

