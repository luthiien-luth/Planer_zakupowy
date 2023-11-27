namespace Planer_zakupowy.Backend.Application.Interfaces
{
    public interface IValidator
    {
        void ValidateInputData(string email, string password);
    }
}
