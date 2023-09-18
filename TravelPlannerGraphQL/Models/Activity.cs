using System.ComponentModel.DataAnnotations;

namespace TravelPlannerGraphQL.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string City { get; set; }
        public int CityID { get; set; }
    }
}
