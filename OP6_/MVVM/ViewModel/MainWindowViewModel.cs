using OP6_.Core;
using OP6_.MVVM.Model;
using OP6_.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
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


        private FilmLocalDB _fLocalDB;
        public FilmLocalDB FlocalDB
        {
            get => _fLocalDB;
            set
            {
                _fLocalDB = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand NavtoKinocommand { get; set; }
        public RelayCommand NavtoDirectcommand { get; set; }
        public RelayCommand SaveOnExitCommand { get; set; }
        public MainWindowViewModel(INavigationService navigation, FilmLocalDB fDB)
        {
            Navigation = navigation;

            FlocalDB = fDB;
            LoadFilmsData();

            Navigation.NavigateTo<FilmotekaViewModel>();

            NavtoKinocommand = new RelayCommand(o => { Navigation.NavigateTo<FilmotekaViewModel>();
            }, o => true);
            NavtoDirectcommand = new RelayCommand(o => { Navigation.NavigateTo<DirectorsViewModel>();
            }, o => true);

            SaveOnExitCommand = new RelayCommand(o => { SaveFilmsData(); }, o => true);
        }

        private void SaveFilmsData()
        {
            Stream stream = null;
            try
            {
                stream = File.Open("FilmData.bin", FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, FlocalDB.FilmsList);
                stream.Close();
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            
        }

        private void LoadFilmsData()
        {
            Stream stream = null;
            try
            {
                stream = File.Open("FilmData.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                FlocalDB.FilmsList = (List<Film>)bf.Deserialize(stream);
            }
            catch
            {

            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }         
        }
    }
}
