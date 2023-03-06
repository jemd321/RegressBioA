using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.Models
{
    public class Project
    {
        private readonly List<AnalyticalRun> _analyticalRuns = new();

        public Project(string name)
        {
            Name = name;
            _analyticalRuns.Add(new AnalyticalRun("Test Run"));
        }

        public string Name { get; private set; }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public Guid ID { get; } = Guid.NewGuid();

        public IEnumerable<AnalyticalRun> AnalyticalRuns => _analyticalRuns;

    }
}
