using System;

namespace Xamarin.Core
{
    public interface IAppStorage
    {
        void Save(string key, int value);

        void Save(string key, string value);

        void Save(string key, bool value);

        void Save(string key, float value);

        void Save(string key, long value);

        int LoadInt(string key, int defValue = 0);

        string LoadString(string key, string defValue = "");

        bool LoadBoolean(string key, bool defValue = false);

        float LoadFloat(string key, float defValue = 0.0f);

        long LoadLong(string key, long defValue = 0);

        void Remove(string key);

        void RemoveAll();

        bool Contains(string key);
    }
}

