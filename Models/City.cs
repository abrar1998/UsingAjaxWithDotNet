using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxDotNet.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public List<State> State { get; set; }
        public List<Student> Students { get; set; }
    }
}
