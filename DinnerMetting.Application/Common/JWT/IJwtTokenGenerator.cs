using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerMetting.Application.Common.JWT;

public interface IJwtTokenGenerator
{
    string Generate(string userId, string firstName, string lastName);
}
