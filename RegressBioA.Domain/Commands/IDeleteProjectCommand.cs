using RegressBioA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.Domain.Commands
{
    public interface IDeleteProjectCommand
    {
        Task Execute(object parameter);
    }
}
