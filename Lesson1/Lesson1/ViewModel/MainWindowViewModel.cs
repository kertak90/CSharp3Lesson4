using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSenderLib.Linq2SQL;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Lesson1.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRecepientsData _RecepientsData;
        private string _Title = "Рассыльщик почты v1";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        private CollectionViewSource _FiltredRecipientsSource;

        private void OnRecipientsFiltred(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Recepients recipient) || string.IsNullOrWhiteSpace(_RecipientNameFilterText)) return;

            if (recipient.Name is null
                || recipient.Name.IndexOf(_RecipientNameFilterText, StringComparison.OrdinalIgnoreCase) < 0)
                e.Accepted = false;
        }

        public ICollectionView FiltredRecipients => _FiltredRecipientsSource?.View;

        private ObservableCollection<Recepients> _Recipients;

        public ObservableCollection<Recepients> Recipients
        {
            get => _Recipients;
            private set
            {
                if (!Set(ref _Recipients, value)) return;

                if (_FiltredRecipientsSource != null)
                    _FiltredRecipientsSource.Filter -= OnRecipientsFiltred;
                _FiltredRecipientsSource = new CollectionViewSource { Source = value };
                _FiltredRecipientsSource.Filter += OnRecipientsFiltred;

                RaisePropertyChanged(nameof(FiltredRecipients));
            }
        }

        private Recepients _SelectedRecepient;

        public Recepients SelectedRecepient
        {
            get => _SelectedRecepient;
            set => Set(ref _SelectedRecepient, value);
        }

        private string _RecipientNameFilterText;

        public string RecipientNameFilterText
        {
            get => _RecipientNameFilterText;
            set
            {
                if (!Set(ref _RecipientNameFilterText, value)) return;
                _FiltredRecipientsSource?.View?.Refresh();
            }
        }

        #region Commands
        public ICommand RefreshDataCommand { get; }
        public ICommand WriteRecipientDataCommand { get; }
        public ICommand CreateNewRecepientCommand { get; }
        
        #endregion

        public MainWindowViewModel(IRecepientsData RecepientsData)
        {
            _RecepientsData = RecepientsData;
            
            RefreshDataCommand = new RelayCommand(OnRefreshDataCommandExecuted, CanrefreshDataCommandExecute);
            WriteRecipientDataCommand = new RelayCommand<Recepients>(OnWriteRecepientDataCommandExecute, CanWriteRecipientDataCommandExecute);
            CreateNewRecepientCommand = new RelayCommand(OnCreateNewRecepientCommandExecute, CanCreateNewRecepientCommandExecute);
        }

        private bool CanCreateNewRecepientCommandExecute() => true;

        private void OnCreateNewRecepientCommandExecute()
        {
            var new_recipient = new Recepients { Name = "Recipient", Email = "recipient@address.com" };
            var id = _RecepientsData.Add(new_recipient);
            if (id == 0) return;
            Recipients.Add(new_recipient);
            SelectedRecepient = new_recipient;

        }

        private bool CanWriteRecipientDataCommandExecute(Recepients recipient) => recipient != null;

        private void OnWriteRecepientDataCommandExecute(Recepients recipient)
        {
            _RecepientsData.Edit(recipient);
            _RecepientsData.SaveChanges();
        }

        private bool CanrefreshDataCommandExecute() => true;

        private void OnRefreshDataCommandExecuted() => LoadData();

        private void LoadData()
        {            
            var recipients = _RecepientsData.GetAll();
            Recipients = new ObservableCollection<Recepients>(recipients);
        }
    }
}
