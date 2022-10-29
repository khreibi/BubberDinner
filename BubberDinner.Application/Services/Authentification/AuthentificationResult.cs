﻿using BubberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Services.Authentification
{
    public record AuthentificationResult
    (
        User user,
        string Token
    );

}
