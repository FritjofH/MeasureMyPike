namespace MeasureMyPike.Service
{
    public interface ISecurityService
    {
        string HashAndSaltPassword(string password);
        bool Login(string username, string password);
    }
}