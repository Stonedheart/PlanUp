namespace PlanUp.Models
{
    internal class EventCategory
    {
        private int Id { get; set; }
        private string CategoryName { get; set; }

        public EventCategory(string categoryName)
        {
            this.CategoryName = categoryName;
        }
    }
}