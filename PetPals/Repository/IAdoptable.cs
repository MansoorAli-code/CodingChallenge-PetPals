﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Repository
{
    internal interface IAdoptable
    {
        bool Adopt(int petId, int userId);

    }
}
