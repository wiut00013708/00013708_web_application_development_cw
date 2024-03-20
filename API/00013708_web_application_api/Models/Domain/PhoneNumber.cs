using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00013708_web_application_api.Models.Domain
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        
        [ForeignKey("ContactId")]
        public int? ContactId { get; set; }
        public Contact? contact { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }


    }
}
