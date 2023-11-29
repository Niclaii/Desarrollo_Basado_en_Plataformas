using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.Views;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace MyCoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Coffee> FavoriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }

        public CoffeeEquipmentViewModel()
        {

            Title = "Nuestro Cafe";

            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            

            LoadMore(); 
            
            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
        }

        async Task Favorite(Coffee coffee)
        {
            if (coffee == null)
                return;

            await Application.Current.MainPage.DisplayAlert("Favorito", coffee.Name, "OK");

        }

        Coffee previouslySelected;
        Coffee selectedCoffee;
        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set => SetProperty(ref selectedCoffee, value);
        }

        async Task Selected(object args)
        {
            var coffee = args as Coffee;
            if (coffee == null)
                return;

            SelectedCoffee = null;


            await AppShell.Current.GoToAsync(nameof(AddMyCoffeePage));
            //await Application.Current.MainPage.DisplayAlert("Selected", coffee.Name, "OK");

        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Coffee.Clear();
            LoadMore();

            IsBusy = false;
        }

        void LoadMore()
        {
            if (Coffee.Count >= 20)
                return;

            var image = "coffeebag.png";
            Coffee.Add(new Coffee { Roaster = "Listo", Name = "Expresso", Image = image });
            Coffee.Add(new Coffee { Roaster = "Listo", Name = "Expresso", Image = image });
            Coffee.Add(new Coffee { Roaster = "Listo", Name = "Expresso", Image = image });
            Coffee.Add(new Coffee { Roaster = "Botella normal", Name = "Cafe", Image = image });
            Coffee.Add(new Coffee { Roaster = "Botella normal", Name = "Cafe", Image = image });

            CoffeeGroups.Clear();

            CoffeeGroups.Add(new Grouping<string, Coffee>("Botella normal", Coffee.Where(c => c.Roaster == "Botella normal")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Si", Coffee.Where(c => c.Roaster == "Listo")));
        }

        void DelayLoadMore()
        {
            if (Coffee.Count <= 10)
                return;

            LoadMore();
         }


        void Clear()
        {
            Coffee.Clear();
            CoffeeGroups.Clear();
        }

    }
}
