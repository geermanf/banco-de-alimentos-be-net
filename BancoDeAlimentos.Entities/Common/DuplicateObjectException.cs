﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeAlimentos.Entities.Common
{
    public class DuplicateObjectException : ArgumentException
    {
        public DuplicateObjectException(string msg = null, ArgumentException inner = null) : base("Ya se encuentra registrado", inner)
        {

        }
    }
}
