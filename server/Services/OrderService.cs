using server.Model;
using server.Entity;
using System.Collections.Generic;
using server.Repository;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace server.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILinkOrderRepository _repository;
       
        public OrderService(ILinkOrderRepository repo)
        {
            _repository = repo;
        }

        /// Add Orders
        /// </summary>
        /// <param name="order"></param>
        /// <returns>OrderList</returns>
        public OrderList Save(List<LinkOrder> order)
        {
            return this._repository.Save(order);
        }
        
    

    }
}
