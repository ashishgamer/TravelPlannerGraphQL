using TravelPlannerGraphQL.Models;

namespace TravelPlannerGraphQL
{
    public class TravelQuery
    {
        private readonly TravelRepository repository;

        public TravelQuery(TravelRepository repository)
        {
            this.repository = repository;
        }

        [GraphQLDescription("Get flights for a specific destination.")]
        public IEnumerable<Flight> GetFlights(string source, string destination)
        {
            return repository.GetFlights(source, destination);
        }

        [GraphQLDescription("Get hotels for a specific destination.")]
        public IEnumerable<Hotel> GetHotels(string destination)
        {
            return repository.GetHotels(destination);
        }

        [GraphQLDescription("Get activities for a specific destination.")]
        public IEnumerable<Activity> GetActivities(string destination)
        {
            return repository.GetActivities(destination);
        }
    }

}
