using System.Security.Cryptography;
using System.Text;

namespace UDVPractice2024VK.Infrastructure;

public class Config
{
    public string DatabaseConnectionString { get; }
    public byte[] PasswordSalt { get; } = new HMACSHA512(Encoding.ASCII.GetBytes("qlsdfgtbzxbs4qwe")).Key;

    public Config(bool isDev)
    {
        DatabaseConnectionString = isDev
            ? "Server=localhost;Database=UdvkDB2024;Port=5432;User Id=postgres;Password=1"
            : Environment.GetEnvironmentVariable("Connection");
    }
}