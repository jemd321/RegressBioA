﻿using RegressBioA.Commands;
using RegressBioA.Stores;
using RegressBioA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.ViewModels.PopupViewModels
{
    public class CreateProjectPopupViewModel : ViewModelBase
    {
        private string _projectName;

        public CreateProjectPopupViewModel(PopupNavigationStore popupNavigationStore, ProjectStore projectStore, AsyncCommandErrorHandler asyncCommandErrorHandler)
        {
            CreateProjectCommand = new CreateProjectCommand(asyncCommandErrorHandler, popupNavigationStore, projectStore, this);
            ClosePopupCommand = new ClosePopupCommand(popupNavigationStore);
        }

        public CreateProjectCommand CreateProjectCommand { get; }

        public ClosePopupCommand ClosePopupCommand { get; }

        public string ProjectName
        {
            get => _projectName;
            set
            {
                _projectName = value;
                OnPropertyChanged();
            }
        }
    }
}
