using OP6_.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP6_.MVVM.Model
{
    public class FilmFilterParameters: ObservableObject
    {
		public Dictionary<string, bool> GenreParameters {  get; set; }

		public FilmFilterParameters()
		{
            GenreParameters = new Dictionary<string, bool>();
        }

        public Dictionary<string, bool> GetGenreFilterParameters()
        {
            return GenreParameters;
        }
        public (int, int) GetDateFilterParameters()
        {
            return (StartDate, EndDate);
        }
        // Filter Reseter -> Dont forget to add here all parameters
        public void ResetAllFilters()
        {
            Horror = false;
            Dram = false;
            Comedy = false;
            Action = false;

            StartDate = 0;
            EndDate = DateTime.Now.Year;

            IsDescending = false;
            IsIncreasing = false;
        }

        private bool _horror;
		public bool Horror
        {
			get => _horror;
			set
			{
                _horror = value;
				GenreParameters["Ужасы"] = Horror;
                OnPropertyChanged();
			}
		}
        private bool _dram;
        public bool Dram
        {
            get => _dram;
            set
            {
                _dram = value;
                GenreParameters["Драма"] = Dram;
                OnPropertyChanged();
            }
        }
        private bool _comedy;
        public bool Comedy
        {
            get => _comedy;
            set
            {
                _comedy = value;
                GenreParameters["Комедия"] = Comedy;
                OnPropertyChanged();
            }
        }
        private bool _action;
        public bool Action
        {
            get => _action;
            set
            {
                _action = value;
                GenreParameters["Боевик"] = Action;
                OnPropertyChanged();
            }
        }
        private int _startDate = 0;
        public int StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }
        private int _endDate = DateTime.Now.Year;
        public int EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }


        private bool _isDescending;
        public bool IsDescending
        {
            get => _isDescending;
            set
            {
                _isDescending = value;
                OnPropertyChanged();
            }
        }
        private bool _isIncreasing;
        public bool IsIncreasing
        {
            get => _isIncreasing;
            set
            {
                _isIncreasing = value;
                OnPropertyChanged();
            }
        }






    }
}
