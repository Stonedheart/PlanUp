using TMDbLib.Objects.Movies;

namespace PlanUp.Controllers.Api
{
    public interface IApi
    {
        void  SetConnection(string newKey);
        void Convert();
        object GetPropostition();
        // git comment
    }
}