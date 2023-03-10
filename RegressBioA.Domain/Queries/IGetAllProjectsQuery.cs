using RegressBioA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.Domain.Queries
{
    public interface IGetAllProjectsQuery
    {
        Task<IEnumerable<Project>> Execute();
    }
}
