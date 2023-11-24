using DinnerMetting.Application.Common;
using DinnerMetting.Application.Persistence;
using DinnerMetting.Domain.Entities;
using DinnerMetting.Domain.Errors;
using DinnerMetting.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerMetting.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Result<AuthenticationResult> Login(
        string email,
        string password)
    {
        // Check the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // Validate the password 
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Create the JWT token
        var token = _jwtTokenGenerator.Generate(user.Id.ToString(), user.FirstName, user.LastName);

        return new AuthenticationResult(
            user.Id,
            user.FirstName,
            user.LastName,
            email,
            token);

    }

    public Result<AuthenticationResult> Register(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // Creatte user (generate unique ID)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        // Create JWT token
        var token = _jwtTokenGenerator.Generate(user.Id.ToString(), firstName, lastName);

        _userRepository.Add(user);

        return new AuthenticationResult(
            user.Id,
            firstName,
            lastName,
            email,
            token);
    }
}
