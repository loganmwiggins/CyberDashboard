using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CyberDashboardProj
{
    public class PasswordCheckerService : IPasswordCheckerService
    {
        private readonly HttpClient _httpClient;

        public PasswordCheckerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CheckPasswordAsync(string password)
        {
            var hash = HashPassword(password);
            var prefix = hash.Substring(0, 5);
            var suffix = hash.Substring(5).ToUpper();

            var response = await _httpClient.GetAsync($"https://api.pwnedpasswords.com/range/{prefix}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var lines = responseBody.Split('\n');

                foreach (var line in lines)
                {
                    var parts = line.Split(':');
                    if (parts[0].Equals(suffix, StringComparison.OrdinalIgnoreCase))
                    {
                        return true; // Password has been compromised
                    }
                }
            }
            return false; // Password not found in compromised passwords
        }

        private string HashPassword(string password)
        {
            using (var sha1 = SHA1.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha1.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
