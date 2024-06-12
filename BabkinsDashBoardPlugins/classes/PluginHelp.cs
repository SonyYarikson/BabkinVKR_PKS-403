﻿using BabkinsDashBoardPlugins.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkinsDashBoardPlugins.classes
{
    public class Help : IPlugin
    {
        public void Go(string parameters)
        {
            foreach (IPlugin plugin in PluginLoader.Plugins)
            {
                Console.WriteLine("{0}: {1}", plugin.Name, plugin.Explanation);
            }
        }

        public string Name
        {
            get
            {
                return "help";
            }
        }

        public string Explanation
        {
            get
            {
                return "This plugin shows all loaded plugins and their explanations";
            }
        }
    }
}