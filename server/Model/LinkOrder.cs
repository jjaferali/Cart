using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
 using Newtonsoft.Json;

namespace server.Model
{
    public class LinkOrder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }

        [JsonProperty(PropertyName = "orderid")]
        public string OrderId { get; set; }
    }
}
