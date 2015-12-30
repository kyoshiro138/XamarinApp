using System;
using System.Threading.Tasks;

namespace Xamarin.Core
{
    public interface IService<T> where T : BaseResponseObject
    {
        Task ExecuteGet(string tag, string url);

        Task ExecuteGet<T1>(string tag, string url) where T1 : T;
    }
}

