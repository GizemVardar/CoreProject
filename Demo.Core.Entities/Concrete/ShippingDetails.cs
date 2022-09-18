using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Core.Entities.Concrete
{
    public class ShippingDetails
    {
        [Required]// Burada firstname gibi alanlar bos gecilemez olarak ayarlandı.
        public string  FirstName { get; set; }
        [Required]
        public string  LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }
        [Required]
        public string  City { get; set; }
        [Required]
        public string  Adress { get; set; }
        [Required]
        [Range(15,75)] //min 15 max 75 degerleri arasında  olmak zorundadır
        public int Age { get; set; }
    }
}
