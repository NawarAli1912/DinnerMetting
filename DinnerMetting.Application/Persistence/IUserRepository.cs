using DinnerMetting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerMetting.Application.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}
