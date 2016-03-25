namespace Xamarin.Core
{
    public interface ITextField : IControl
    {
        string Input {get;set;}
        string Label {get;set;}
        string Hint {get;set;}
        string Helper {get;set;}
        string Error {get;set;}
        bool ErrorEnabled {get;set;}
        InputType InputType {set;}
    }
}

