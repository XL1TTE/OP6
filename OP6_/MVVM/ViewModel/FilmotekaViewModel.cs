using OP6_.Core;
using OP6_.MVVM.Model;
using OP6_.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OP6_.MVVM.ViewModel
{
    public class FilmotekaViewModel: ViewModelBase
    {
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }



        private ObservableCollection<Film> _filmsToShow;
        public ObservableCollection<Film> FilmsToShow
        {
            get => _filmsToShow;
            set
            {
                _filmsToShow = value;
                OnPropertyChanged();
            }
        }

        private FilmFilterParameters _filmFilterParameters;
        public FilmFilterParameters FilmFilterParameters
        {
            get => _filmFilterParameters;
            set
            {
                _filmFilterParameters = value;
                OnPropertyChanged();
            }
        }
        private FilteringService _filteringService;
        public FilteringService FilteringService
        {
            get => _filteringService;
            set
            {
                _filteringService = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand FilterCommand {  get; set; }
        public RelayCommand ResetFiltersCommand { get; set; }
        public FilmotekaViewModel(INavigationService navigation, FilmFilterParameters filterParameters,
            FilteringService filteringService)
        {
            Navigation = navigation;
            FilteringService = filteringService;
            FilmFilterParameters = filterParameters;

            FilmsToShow = FilteringService.ResetFilters();

            FilterCommand = new RelayCommand(o => { FilmsToShow = FilteringService.Filter(); }, o => true);
            ResetFiltersCommand = new RelayCommand(o => { FilmsToShow = FilteringService.ResetFilters(); }, o => true);
        }

        private void UpdateFilmsList()
        {

        }
    }
}
