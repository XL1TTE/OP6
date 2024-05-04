using OP6_.Core;
using OP6_.MVVM.Model;
using OP6_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace OP6_.MVVM.ViewModel
{
    public class DirectorsViewModel: ViewModelBase
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
        private FilmLocalDB _filmDB;
        public FilmLocalDB FilmDB
        {
            get => _filmDB;
            set
            {
                _filmDB = value;
                OnPropertyChanged();
            }
        }
        private List<String> _GenreList;
        public List<String> GenreList
        {
            get => _GenreList;
            set
            {
                _GenreList = value;
                OnPropertyChanged();
            }
        }
        private FilteringService _filteringService;
        public FilteringService Filteringservice
        {
            get => _filteringService;
            set
            {
                _filteringService = value;
                OnPropertyChanged();
            }
        }

        private List<dynamic> _directrosList;
        public List<dynamic> DirectrosList
        {
            get => _directrosList;
            set
            {
                _directrosList = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddMovieCommand {  get; set; }
        public RelayCommand UpdateListCommand { get; set; }

        public DirectorsViewModel(INavigationService navigationServ, FilmFilterParameters filteParam, FilmLocalDB filmDB, FilteringService filteringService)
        {
            Navigation = navigationServ;
            Filteringservice = filteringService;

            FilmDB = filmDB;

            GenreList = filteParam.GenreParameters.Select(p => p.Key).ToList();
            UpdateDirectorsList();

            AddMovieCommand = new RelayCommand(o => { CreateMovie(); UpdateDirectorsList(); }, o => IsMovieValidToCreate());
            UpdateListCommand = new RelayCommand(o => { UpdateDirectorsList(); }, o => true);

        }

        private void UpdateDirectorsList()
        {
            DirectrosList = Filteringservice.GetFilteredDirectors();
        }

        private bool IsMovieValidToCreate()
        {
            try
            {
                bool a = FilmToAddTitle.Length >= 4;
                bool b = FilmToAddDirectorName.Length >= 4;
                bool c = Convert.ToInt32(FilmToAddReleaseDate) >= 1000 && Convert.ToInt32(FilmToAddReleaseDate) <= DateTime.Now.Year;
                bool d = FilmToAddGenre != "";
                bool g = Convert.ToDouble(FilmToAddRating) >= 0 && Convert.ToDouble(FilmToAddRating) <= 10;
                return a && b && c && d;
            }
            catch
            {
                return false;
            }

        }
        private void CreateMovie()
        {
            FilmDB.FilmsList.Add(
                new Film(FilmToAddTitle, "Отсутствует описание", FilmToAddDirectorName, Convert.ToInt32(FilmToAddReleaseDate), Convert.ToDouble(FilmToAddRating), FilmToAddGenre)
                );
        }

        private string _filmToAddtitle = "";
        public string FilmToAddTitle
        {
            get => _filmToAddtitle;
            set
            {
                _filmToAddtitle = value;
                OnPropertyChanged();
            }
        }
        private string _filmToAddGenre = "";
        public string FilmToAddGenre
        {
            get => _filmToAddGenre;
            set
            {
                _filmToAddGenre = value;
                OnPropertyChanged();
            }
        }
        private string _filmToAddReleaseDate = "";
        public string FilmToAddReleaseDate
        {
            get => _filmToAddReleaseDate;
            set
            {
                _filmToAddReleaseDate = value;
                OnPropertyChanged();
            }
        }
        private string _filmToAddDirectorName = "";
        public string FilmToAddDirectorName
        {
            get => _filmToAddDirectorName;
            set
            {
                _filmToAddDirectorName = value;
                OnPropertyChanged();
            }
        }
        private string _filmToAddRating = "";
        public string FilmToAddRating
        {
            get => _filmToAddRating;
            set
            {
                _filmToAddRating = value;
                OnPropertyChanged();
            }
        }
    }
}
