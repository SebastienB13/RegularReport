using System.Security.Cryptography;
using System.Text;
using MainCourante.Data;
using MainCourante.Core.Models;

public class AuthService
{
    private readonly MainCouranteDbContext _db;

    public AuthService(MainCouranteDbContext db)
    {
        _db = db;
    }

    public bool Login(string username, string password)
    {
        string hash = Hash(password);

        var user = _db.Users.FirstOrDefault(u => u.Username == username);

        if (user == null) return false;

        return user.PasswordHash == hash;
    }

    public static string Hash(string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToString(bytes).Replace("-", "");
    }
}
