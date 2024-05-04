using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Documents;

namespace OP6_.MVVM.Model
{
    [Serializable]
    public class Film
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Producer {  get; set; }
        public int PremierDate { get; set; }
        public double Rating {  get; set; }
        public string Genre { get; set; }

        public Film(string title, string description, string producer, int premierDate, double rating, string genre)
        {
            Title = title;
            Description = description;
            Producer = producer;
            PremierDate = premierDate;
            Rating = rating;
            Genre = genre;
        }
    }
    public class FilmLocalDB
    {
        public FilmLocalDB()
        {
            FilmsList = new List<Film>();
            AddFilm(new Film[]
{
            new Film("Опенгеймер", "Про ученого который придумал атомную бомбу", "Кристофер Нолан", 2023, 8.5, "Ужасы"),
            new Film("Человек Паук", "Про человека но паука", "не помню", 2005, 4.5, "Комедия"),
            new Film("1+1", "Аристократ на коляске нанимает в сиделки бывшего заключенного. Искрометная французская комедия с Омаром Си", "Оливье Накаш, Эрик Толедано", 2011, 8.8, "Комедия"),
            new Film("Реквием по мечте", "Каждый стремится к своей заветной мечте. Сара Голдфарб мечтала сняться в известном телешоу, ее сын Гарольд с другом Тайроном — сказочно разбогатеть, подруга Гарольда Мэрион грезила о собственном модном магазине, но на их пути были всевозможные препятствия.", "Даррен Аронофски", 2000, 8.0, "Драма"),
            new Film("Агент Ева", "расивая, умная и опасная Ева – один из лучших агентов-киллеров в мире. Когда начальство решает, что она стала неуправляемой, за ней самой начинается охота.", "Тейт Тейлор", 2020, 4.5, "Боевик")
});
        }
        public List<Film> FilmsList { get; set; }

        public void AddFilm(Film film)
        {
            FilmsList.Add(film);
        }
        public void AddFilm(Film[] films)
        {
            foreach(var film in films)
                FilmsList.Add(film);
        }
        public void RemoveFilm(Film film)
        {
            FilmsList.Remove(film);
        }

    }
}
