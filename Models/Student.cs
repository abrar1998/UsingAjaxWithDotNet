using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxDotNet.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address {  get; set; }

        public string? PhotoAddress { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public int Country {  get; set; }
        [ForeignKey("Country")]
        public List<Country> CountryList { get; set; }

        public int State {  get; set; }
        [ForeignKey("State")]
        public List<State> StateList { get; set; }

        public int City {  get; set; }
        [ForeignKey("City")]
        public List<City> CityList { get;}

    }
}
