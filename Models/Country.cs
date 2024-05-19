namespace AjaxDotNet.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName {  get; set; }
        public List<Student> Student { get; set; }
        public List<State> State { get; set; }
    }
}
