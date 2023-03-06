using RegressBioA.Models;
using RegressBioA.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RegressBioA.ViewModels
{
    public class AnalyticalRunListingViewModel : ViewModelBase
    {
        private bool _disposed;
        private SelectedProjectStore _projectStore;
        private bool _hasAnalyticalRuns;
        private readonly ObservableCollection<AnalyticalRun> _analyticalRuns = new();

        public AnalyticalRunListingViewModel(SelectedProjectStore projectStore)
        {
            _projectStore = projectStore;
            RefreshAnalyticalRuns();

            WeakEventManager<SelectedProjectStore, EventArgs>.AddHandler(projectStore, nameof(projectStore.SelectedProjectChanged), projectStore_SelectedProjectChanged);


            // projectStore.SelectedProjectChanged += projectStore_SelectedProjectChanged;
        }

        private void RefreshAnalyticalRuns()
        {
            if (SelectedProject is not null && SelectedProject.AnalyticalRuns.Any())
            {
                _analyticalRuns.Clear();
                foreach (AnalyticalRun analyticalRun in SelectedProject.AnalyticalRuns)
                {
                    _analyticalRuns.Add(analyticalRun);
                }
            }
        }

        public Project SelectedProject => _projectStore.SelectedProject;

        public bool HasAnalyticalRuns => SelectedProject is not null && _analyticalRuns.Any();
        public IEnumerable<AnalyticalRun> AnalyticalRuns => _analyticalRuns;

        private void projectStore_SelectedProjectChanged(object sender, EventArgs e)
        {
            RefreshAnalyticalRuns();
            OnPropertyChanged(nameof(AnalyticalRuns));
            OnPropertyChanged(nameof(HasAnalyticalRuns));
        }

    }
}