﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BLL.UserStore.Interface
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
