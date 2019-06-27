namespace AdPage.Interfaces
{
    public interface IHud
    {
        void Show(string message);

        void Error(string message);
        void Success(string message);
        void Dismiss();
    }
}