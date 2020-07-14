using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model
{
    public class OrderList
    {
       
            public List<LinkOrder> SuccessList { get; set; }
            public List<LinkOrder> FailedList{ get; set; }
       

    }
}
