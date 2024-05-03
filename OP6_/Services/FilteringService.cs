using OP6_.MVVM.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP6_.Services
{
    public class FilteringService
    {
        private readonly FilmFilterParameters _filterParameters;

        private readonly FilmLocalDB _filmLocaldb;

        public FilteringService(FilmFilterParameters filterParameters, FilmLocalDB filmdB)
        {
            this._filterParameters = filterParameters;
            this._filmLocaldb = filmdB;
        }
        public ObservableCollection<Film> Filter()
        {
            var temp = new ObservableCollection<Film>(
                FilterByReleaseDate(FilterByGenre(_filmLocaldb.FilmsList))
                );
            return temp;
        }
        public ObservableCollection<Film> ResetFilters()
        {
            _filterParameters.ResetAllFilters();
            var temp = new ObservableCollection<Film>(_filmLocaldb.FilmsList);
            return temp;
        }
        public List<Film> FilterByGenre(List<Film> FilmsListToShow)
        {          
            var FilterGenreParam = _filterParameters.GetGenreFilterParameters();

            FilterGenreParam = FilterGenreParam.Where(x => x.Value == true).ToDictionary(x => x.Key, x => x.Value);
            if(FilterGenreParam.Count != 0)
            {
                var temp = FilmsListToShow.Where(f => FilterGenreParam.ContainsKey(f.Genre) && FilterGenreParam[f.Genre])
                    .OrderByDescending(f => Convert.ToInt32(f.PremierDate))
                    .ToList();
                return temp;
            }
            return _filmLocaldb.FilmsList;
        }
        public List<Film> FilterByReleaseDate(List<Film> FilmsListToShow)
        {
            var FilterDateParam = _filterParameters.GetDateFilterParameters();
            var temp = FilmsListToShow.Where(f => (f.PremierDate <= FilterDateParam.Item2) && (f.PremierDate >= FilterDateParam.Item1))
                .OrderByDescending(f => Convert.ToInt32(f.PremierDate))
                .ToList();
            return temp;
        }
    }
}
