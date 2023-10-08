namespace Planer_zakupowy.Backend.Application.Interfaces
{
    public interface IValidator
    {
        void ValidateRegistrationData(string email, string password);
    }
}
