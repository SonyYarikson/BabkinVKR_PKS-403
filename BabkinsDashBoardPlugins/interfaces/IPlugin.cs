﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkinsDashBoardPlugins.interfaces
{
    public interface IPlugin
    {
        string Name { get; }
        string Explanation { get; }
        void Go(string parameters);
    }
}
