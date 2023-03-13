using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.EntityFramework.DTOs
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<AnalyticalRunDTO> AnalyticalRuns { get; set; }
    }
}
