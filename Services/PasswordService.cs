using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class PasswordService
{
    private readonly HttpClient _httpClient;

    public PasswordService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> CheckIfPasswordCompromised(string password)
    {
        // Hash the password using SHA-1
        var hashedPassword = HashPassword(password);
        //variable stores the first 5 values of the hash (this is what is contacted and posted to API)
        var prefix = hashedPassword.Substring(0, 5);
        //the last bit after the prefix
        var suffix = hashedPassword.Substring(5);

        // Construct the API URL
        string url = $"https://api.pwnedpasswords.com/range/{prefix}";
        //notice how prefix is sent to the api

        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Read the response content
            var content = await response.Content.ReadAsStringAsync();
            var lines = content.Split('\n');

            // Check if the hashed password's suffix exists in the response
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts[0].Equals(suffix, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Password is compromised
                }
            }
            return false; // Password is not compromised
        }
        catch (HttpRequestException)
        {
            // Handle exceptions (e.g., network issues)
            return false;
        }
    }

    private string HashPassword(string password)
    {
        using (var sha1 = SHA1.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha1.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
