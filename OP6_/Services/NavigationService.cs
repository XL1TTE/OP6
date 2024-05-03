using OP6_.Core;
using OP6_.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP6_.Services
{
    public interface INavigationService
    {
        ViewModelBase CurrentViewModel {  get; }
        void NavigateTo<ViewModel>() where ViewModel : ViewModelBase;
    }
    public class NavigationService : ObservableObject ,INavigationService
    {
        private readonly Func<Type, ViewModelBase> _viewModelFactory;
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }
        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        public void NavigateTo<ViewModel>() where ViewModel : ViewModelBase
        {
            ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(ViewModel));
            CurrentViewModel = viewModel;
        }
    }
}
