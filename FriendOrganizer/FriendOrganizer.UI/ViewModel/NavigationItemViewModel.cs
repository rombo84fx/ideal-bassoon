using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        public int Id { get; set; }
        private string _displayMember;
        private readonly IEventAggregator _eventAggregator;
        private readonly string _detailViewModelName;

        public ICommand OpenDetailViewCommand { get; }
        public string DisplayMember
        {
            get => _displayMember;
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator,
            string detailViewModelName)
        {
            _eventAggregator = eventAggregator;
            _detailViewModelName = detailViewModelName;
            Id = id;
            DisplayMember = displayMember;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
        }

        private void OnOpenDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenDetailViewEvent>().Publish(new OpenDetailViewEventArgs
            {
                Id = Id,
                ViewModelName = _detailViewModelName
            });
        }
    }
}