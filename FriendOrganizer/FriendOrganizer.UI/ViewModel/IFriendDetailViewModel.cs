using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.ViewModel
{
    public interface IFriendDetailViewModel
    {
        Task LoadAsync(int friendId);
    }
}