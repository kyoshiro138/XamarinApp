using Android.Content;
using Android.App;

namespace Xamarin.Core.Android
{
    public class ApplicationPreferences : IAppStorage
    {
        public ISharedPreferences SharedPreferences { get; protected set; }

        public ApplicationPreferences()
            : this(FileCreationMode.Private)
        {
        }

        public ApplicationPreferences(FileCreationMode mode)
            : this(Application.Context.PackageName, mode)
        {
        }

        public ApplicationPreferences(string prefName, FileCreationMode mode)
        {
            SharedPreferences = Application.Context.GetSharedPreferences(prefName, mode);
        }

        public void Save(string key, int value)
        {
            var editor = SharedPreferences.Edit();
            editor.PutInt(key, value);
            editor.Commit();
        }

        public void Save(string key, string value)
        {
            var editor = SharedPreferences.Edit();
            editor.PutString(key, value);
            editor.Apply();
        }

        public void Save(string key, bool value)
        {
            var editor = SharedPreferences.Edit();
            editor.PutBoolean(key, value);
            editor.Apply();
        }

        public void Save(string key, float value)
        {
            var editor = SharedPreferences.Edit();
            editor.PutFloat(key, value);
            editor.Apply();
        }

        public void Save(string key, long value)
        {
            var editor = SharedPreferences.Edit();
            editor.PutLong(key, value);
            editor.Apply();
        }

        public int LoadInt(string key, int defValue = 0)
        {
            if (SharedPreferences != null)
            {
                return SharedPreferences.GetInt(key, defValue);
            }
            return defValue;
        }

        public string LoadString(string key, string defValue = "")
        {
            if (SharedPreferences != null)
            {
                return SharedPreferences.GetString(key, defValue);
            }
            return defValue;
        }

        public bool LoadBoolean(string key, bool defValue = false)
        {
            if (SharedPreferences != null)
            {
                return SharedPreferences.GetBoolean(key, defValue);
            }
            return defValue;
        }

        public float LoadFloat(string key, float defValue = 0.0f)
        {
            if (SharedPreferences != null)
            {
                return SharedPreferences.GetFloat(key, defValue);
            }
            return defValue;
        }

        public long LoadLong(string key, long defValue = 0)
        {
            if (SharedPreferences != null)
            {
                return SharedPreferences.GetLong(key, defValue);
            }
            return defValue;
        }

        public void Remove(string key)
        {
            var editor = SharedPreferences.Edit();
            editor = editor.Remove(key);
            editor.Apply();
        }

        public void RemoveAll()
        {
            var editor = SharedPreferences.Edit();
            editor = editor.Clear();
            editor.Apply();
        }

        public bool Contains(string key)
        {
            if (SharedPreferences != null)
            {
                return SharedPreferences.Contains(key);
            }
            return false;
        }
    }
}

