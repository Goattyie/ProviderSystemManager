using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Enums;
using ProviderSystemManager.DAL.Models;
using System.Security.Cryptography;

namespace ProviderSystemManager.DAL.TableCreators;


public class UserCreator
{
    public static void Init(ProviderDbContext context)
    {
        var user1 = new User() { Login = "operator1", Password = "1954", Role = UserRole.Operator };
        var user2 = new User() { Login = "userr", Password = "1955", Role = UserRole.User };
        var user3 = new User() { Login = "employee_1", Password = "1956", Role = UserRole.Admin };

        context.Users?.Add(user1);
        context.Users?.Add(user2);
        context.Users?.Add(user3);

        context.SaveChanges();

        context.Entry(user1).State = EntityState.Detached;
        context.Entry(user2).State = EntityState.Detached;
        context.Entry(user3).State = EntityState.Detached;
    }
    
    private static string HashPassword(string password)
    {
        byte[] salt;
        
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
        
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
        var hash = pbkdf2.GetBytes(20);
        var hashBytes = new byte[36];
        
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);
        
        return Convert.ToBase64String(hashBytes);
    }
}