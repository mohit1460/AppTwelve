using System.ComponentModel.DataAnnotations;

namespace AppTwelve.Models
{
    public class Shares
    {
        [Key]
        public string symbol { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public string exchange { get; set; }
        public string type { get; set; }
        public string mic_code { get; set; }

    }
}