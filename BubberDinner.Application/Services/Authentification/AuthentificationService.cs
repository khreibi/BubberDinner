using BubberDinner.Application.Common.Authentification;
using BubberDinner.Application.Interfaces.Common.Persistance;
using BubberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Services.Authentification
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthentificationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthentificationResult Login(string email, string password)
        {
            //validate user exist
            var user = _userRepository.GetUserByEmail(email);
            if (user is null)
            {
                throw new Exception("User does not exist...");
            }
            //validate password
            if(user.Password != password)
            {
                throw new Exception("Invalid password...");
            }
            //create JWT token
            var token = _jwtTokenGenerator.GenerateToken(
                user);
            return new AuthentificationResult(
                user, token);
        }

        public AuthentificationResult Register(string firstName, string lastName, string email, string password)
        {
            //Check if user already exist
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User already exist...");
            }
            //Create user (generate unique ID)
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);
            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthentificationResult(user, token);
        }
    }
}
