using SelectAnime.Helper;
using SelectAnime.Models;

using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SelectAnime.ViewModels
{
  public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; set; }

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
