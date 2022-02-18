using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SharedTrip.Contracts;
using SharedTrip.Data.Models;
using SharedTrip.Models.ErrorViewModels;
using SharedTrip.Models.Users;

namespace SharedTrip.Services;

public class UserService : IUserService
{

    private readonly IValidationService validationService;
    private readonly IRepository repo;

    public UserService(IValidationService validationService, IRepository repo)
    {
        this.validationService = validationService;
        this.repo = repo;
    }

    public (bool, ICollection<ErrorViewModel>) RegisterUser(UserRegisterViewModel model)
    {
        var (isValid, errors) = validationService.ValidateModel(model);

        if (isValid == false)
        {
            return (isValid, errors);
        }

        User user = new User()
        {
            Username = model.Username,
            Email = model.Email,
            Password = this.HashingPassword(model.Password)

        };

        try
        {
            repo.Add(user);
            repo.SaveChanges();
            isValid = true;
        }
        catch (Exception)
        {
            isValid = false;
            errors.Add(new ErrorViewModel("Could not register user.Please try again."));
        }

        return (isValid, errors);
    }

    public string LoginUser(UserLoginViewModel model)
    {
        var (isValid, errors) = validationService.ValidateModel(model);

        if (isValid == false)
        {
            return null;
        }

        var user = this.GetUserByUsername(model.Username);

        if (user==null || CheckPasswords(user.Password, model.Password))
        {
            return null;
        }

        return user.Id;

    }

   

    public User GetUserByUsername(string username)
    {
        return this.repo.All<User>().FirstOrDefault(u => u.Username == username);
    }

    private string HashingPassword(string rawData)
    {

        using (SHA256 sha256Hash = SHA256.Create())
        {

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    private bool CheckPasswords(string userPassword, string modelPassword)
    {
        return userPassword == this.HashingPassword(modelPassword);
    }
}