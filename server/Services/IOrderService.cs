using Newtonsoft.Json;
using server.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IOrderService
    {
        
        OrderList Save(List<LinkOrder> order);
    
    }
}
