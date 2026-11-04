using Zxcvbn;

namespace Services
{
    public interface IPasswordService
    {
        Result GetStrongPassword(string pass);
    }
}