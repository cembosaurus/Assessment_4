namespace CheckApp.Services
{
    public interface ICheckService
    {
        string Result { get; }

        string MoneyToWords(decimal d);
    }
}