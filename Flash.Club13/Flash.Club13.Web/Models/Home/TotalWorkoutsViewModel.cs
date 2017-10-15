namespace Flash.Club13.Web.Models.Home
{
    public class TotalWorkoutsViewModel
    {
        public TotalWorkoutsViewModel()
        {

        }

        public TotalWorkoutsViewModel(int count)
        {
            this.Count = count;
        }

        public int Count { get; set; }
    }
}