using RegressBioA.WPF.Stores;
using RegressBioA.WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.WPF.Commands
{
    public class LoadProjectsCommand : AsyncCommandBase
    {
        private readonly IErrorHandler _errorHandler;
        private readonly ProjectStore _projectStore;

        public LoadProjectsCommand(IErrorHandler errorHandler, ProjectStore projectStore) : base(errorHandler)
        {
            _errorHandler = errorHandler;
            _projectStore = projectStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            await _projectStore.Load();
        }
    }
}
