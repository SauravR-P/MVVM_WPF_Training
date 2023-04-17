using API_Service;
using API_Service.Model;
using Commands;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace BusinessModel
{
    public class BooksViewModel : INotifyPropertyChanged
    {

        private readonly HttpClient _client;
        private ObservableCollection<Books> _Books ;
        public ObservableCollection<Books> Books { get { return _Books; } set { _Books = value; OnPropertyChange("Books"); } }

        public BooksViewModel( HttpClient client)
        {
          
            _client = client;
            Books = get().Result;

        }
        string BaseUrl = "https://localhost:7085/";

        public async Task<ObservableCollection<Books>> get()
        {
            try
            {
                var url = "https://localhost:7085/GETALL";
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
        public async Task<Task> DeleteById(Books book)
        {
            BaseUrl = "https://localhost:7085/Delete?id=";

            var id = book.Id;
            var httpResponse = await _client.DeleteAsync($"{BaseUrl}{id}").ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot Delete tasks");
            }
            return Task.CompletedTask;
        }
        public async Task<Books> UpsertAsync(Books task)
        {
            BaseUrl = "https://localhost:7085/Upsert";
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json")).ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add/update task");
            }

            var createdTask = JsonConvert.DeserializeObject<Books>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

      

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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
                        param => UpsertAsync((Books)param),
                        param => CanClick());
                }
                return _clickcommand_Add;
            }
        }

    }

    #endregion

}

