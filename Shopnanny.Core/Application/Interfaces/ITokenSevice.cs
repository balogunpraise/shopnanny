﻿using Shopnanny.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Application.Interfaces
{
    public interface ITokenSevice
    {
        string GenerateToken(ApplicationUser user);
    }
}
