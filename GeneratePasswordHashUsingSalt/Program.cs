// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");
var res = GeneratePasswordHashUsingSalt("Abc123456789*", new byte[16]
{
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,16
});
Console.WriteLine(res);
Console.ReadKey();
 string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
{

    var iterate = 10000;
    var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
    byte[] hash = pbkdf2.GetBytes(20);

    byte[] hashBytes = new byte[36];
    Array.Copy(salt, 0, hashBytes, 0, 16);
    Array.Copy(hash, 0, hashBytes, 16, 20);

    var passwordHash = Convert.ToBase64String(hashBytes);
    pbkdf2.Dispose();
    return passwordHash;

}