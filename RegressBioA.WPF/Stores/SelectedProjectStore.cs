using RegressBioA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.WPF.Stores
{
    public class SelectedProjectStore
    {
        private Project _selectedProject;

        public Project SelectedProject
        {
            get
            {
                return _selectedProject;
            }

            set
            {
                _selectedProject = value;
                SelectedProjectChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler SelectedProjectChanged;
    }
}
