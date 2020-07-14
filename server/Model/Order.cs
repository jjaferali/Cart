using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Model
{
   
    public class Order
    {
       // [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [JsonProperty(PropertyName = "orderid")]
        public int OrderId { get; set; }

        [JsonProperty(PropertyName = "categoryid")]
        public int CategoryId { get; set; }

        
       
    }
}
