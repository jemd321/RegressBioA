﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.Models
{
    public class AnalyticalRun
    {

        public AnalyticalRun(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
