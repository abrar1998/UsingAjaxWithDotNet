using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxDotNet.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId {  get; set; }

        [ForeignKey("CountryId")]
        public List<Country> Countries { get; set; }
        public List<Student> Students { get; set; }
        public List<City> Cities { get; set; }
    }
   
}
