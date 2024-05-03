using OP6_.Core;
using OP6_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace OP6_.MVVM.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
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


        private string _textbox = "";
        public string Textbox
        {
            get => _textbox;
            set
            {
                _textbox = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavtoKinocommand { get; set; }
        public MainWindowViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            Navigation.NavigateTo<FilmotekaViewModel>();
        }

    }
}
