namespace PlanUp.Models
{
    public class EventCategory
    {
        public int Id { get; set; }
        private string CategoryName { get; set; }

        public EventCategory(string categoryName)
        {
            this.CategoryName = categoryName;
        }
    }
}