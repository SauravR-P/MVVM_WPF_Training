
using Commands;
using DataModel.BooksModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Input;

namespace BusinessModel
{
    public class BooksViewModel : INotifyPropertyChanged
    {

        private readonly HttpClient _client;
        string BaseUrl = "https://localhost:7085/";
        private ObservableCollection<Books> _Books ;
        public ObservableCollection<Books> Books_Obs { get { return _Books; } set { _Books = value; OnPropertyChange("Books"); } }
        public BooksViewModel( HttpClient client)
        {
          
            _client = client;
            Books_Obs = get().Result;

        }  
        #region HttpCalls
        //HttpCall for getting records
        public async Task<ObservableCollection<Books>> get()
        {
            try
            {
                var url = "https://localhost:7051/Get";
                var response = "";
                using (var client = new HttpClient())
                {
                    HttpResponseMessage result = await client.GetAsync(url).ConfigureAwait(false);
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                    }
                    var tasks = JsonConvert.DeserializeObject<List<Books>>(response);
                    var books = new ObservableCollection<Books>(tasks);
                    return await Task.FromResult<ObservableCollection<Books>>(books);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        //Detele Method
        public async Task<Task> DeleteById(Books book)
        {
            var id = book.BookId;
            Books_Obs.Remove(book);
            return Task.CompletedTask;
        }

        //HttpCall for record insert and update
        public async Task<Books> UpsertAsync()
        {
            BaseUrl = "https://localhost:7051/Upsert";
            var content = JsonConvert.SerializeObject(Books_Obs);
            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json")).ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add/update task");
            }

            var createdTask = JsonConvert.DeserializeObject<Books>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        } 
        #endregion
        #region NotifyChange
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
        #region commands
        private ICommand _clickcommand_Del, _clickcommand_Add;
        public bool CanClick() { return true; }
        public ICommand ClickCommand_Delete
        {
            get
            {
                if (_clickcommand_Del == null)
                {
                    _clickcommand_Del = new RelayCommand(
                        param => DeleteById((Books)param));

                }
                return _clickcommand_Del;
            }
        }
        public ICommand ClickCommand_Add
        {
            get
            {
                if (_clickcommand_Add == null)
                {
                    _clickcommand_Add = new RelayCommand(
                        param => UpsertAsync(),
                        param => CanClick());
                }
                return _clickcommand_Add;
            }
        }

    }

    #endregion

}

