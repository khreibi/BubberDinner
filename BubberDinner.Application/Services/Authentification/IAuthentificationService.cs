﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Services.Authentification
{
    public interface IAuthentificationService
    {
        public AuthentificationResult Login(string email, string password);
        public AuthentificationResult Register(string firstName, string lastName, string email, string password);
    }
}
