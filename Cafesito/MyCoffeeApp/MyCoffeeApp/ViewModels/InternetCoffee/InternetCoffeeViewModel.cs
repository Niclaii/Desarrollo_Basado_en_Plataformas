using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Services;
using MyCoffeeApp.Shared.Models;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace MyCoffeeApp.ViewModels
{
    public class InternetCoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Coffee> RemoveCommand { get; }


        public InternetCoffeeViewModel()
        {

            Title = "Por internet (cafe)";

            Coffee = new ObservableRangeCollection<Coffee>();
  

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
        }

        async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Nombre", "NBombre del cafe");
            var roaster = await App.Current.MainPage.DisplayPromptAsync("Cafe", "Cafe molido");
            await InternetCoffeeService.AddCoffee(name, roaster);
            await Refresh();
        }

        async Task Remove(Coffee coffee)
        {
            await InternetCoffeeService.RemoveCoffee(coffee.Id);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Coffee.Clear();

            var coffees = await InternetCoffeeService.GetCoffee();

            Coffee.AddRange(coffees);

            IsBusy = false;
        }
    }
}
