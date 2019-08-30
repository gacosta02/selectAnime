using SelectAnime.Helper;
using SelectAnime.Models;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SelectAnime.ViewModels
{
  public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Amiibo> Amiibos { get; set; }
        public ICommand SearchCommand { get; set; }

        public MainPageViewModel()
        {
            SearchCommand = new
                Command(async (Text) =>
                {
                    string url = "https://www.amiiboapi.com/api/amiibo/?name={Text}";
                    var service =
                    new HttpHelper<Amiibos>();
                    var amiibos =
                    await service.GetRestServiceDataAsync(url);
                    Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);
                });
        }
        public async Task LoadCHaraters()
        {
            var url = "https://www.amiiboapi.com/api/character";
            var service =
                new HttpHelper<Characters>();
            var characters = await service.GetRestServiceDataAsync(url);
            Characters = new ObservableCollection<Character>(characters.amiibo);
        }
    }
}
