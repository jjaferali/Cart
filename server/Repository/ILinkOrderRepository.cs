using Newtonsoft.Json;
using server.Model;
using System.Collections.Generic;

namespace server.Repository
{
    public interface ILinkOrderRepository
    {

        OrderList Save(List<LinkOrder> order);
                     
    }
}
