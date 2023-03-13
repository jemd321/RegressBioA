using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.Domain.Models
{
    public class Project
    {
        private readonly List<AnalyticalRun> _analyticalRuns = new();

        public Project(Guid id, string name, List<AnalyticalRun> analyticalRuns)
        {
            Id = id;
            Name = name;
            _analyticalRuns = analyticalRuns;
            _analyticalRuns.Add(new AnalyticalRun("Test Run", Guid.NewGuid()));
        }

        public string Name { get; private set; }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public Guid Id { get; }

        public IEnumerable<AnalyticalRun> AnalyticalRuns => _analyticalRuns;

    }
}
