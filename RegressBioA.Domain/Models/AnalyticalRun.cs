using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.Domain.Models
{
    public class AnalyticalRun
    {

        public AnalyticalRun(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}
