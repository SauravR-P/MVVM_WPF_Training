namespace BackgroundService
{
    public class Date_TimeService : IDate_TimeService
    {
        private DateTime _date;
        public DateTime Date { get { return DateTime.Now; } set { _date = value; } }
        public Date_TimeService()
        { }   

        public DateTime GetDate() { return Date; }


    }
}