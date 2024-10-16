using System.Threading.Tasks;

namespace CyberDashboardProj
{
    public interface IPasswordCheckerService
    {
        Task<bool> CheckPasswordAsync(string password);
    }
}
