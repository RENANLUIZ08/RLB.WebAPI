using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Domain.Interface.Services
{
    public interface IJwtService
    {
        string GenerateToken();
    }
}
