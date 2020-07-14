using server.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using server.Entity;

namespace server.Repository
{
    public class LinkOrderRepository : ILinkOrderRepository
    {
        private readonly IOrderDbContext _context;
       
        public LinkOrderRepository(IOrderDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Add Link orders
        /// </summary>
        /// <param name="order">List<LinkOrder></param>
        /// <returns>OrderList</returns>
        public OrderList Save(List<LinkOrder> order)
        {
            
            var OrderList = new OrderList();
            OrderList.SuccessList = new List<LinkOrder>();
            OrderList.FailedList= new List<LinkOrder>();
            List<int> listOrders = new List<int>();
            List<LinkOrder> failedOrders = new List<LinkOrder>();

            var objGroupedOrders = this._context.Order.GroupBy(d => d.CategoryId);

                foreach (var objGroupedOrder in objGroupedOrders)
                {
                foreach (var obj2 in objGroupedOrder)
                {
                    foreach (var orderList in order)
                    {
                        if (orderList.OrderId == obj2.OrderId.ToString())
                        {
                            var existOrder = this._context.LinkOrder.Where(x => x.OrderId.Contains(obj2.OrderId.ToString()));
                            if (existOrder.Count() == 0) 
                            
                                listOrders.Add(obj2.OrderId);                            
                            else
                                 failedOrders.AddRange(existOrder);
                             
                        }
                    }
                }
                        string OrderIds = string.Join(",", listOrders.Distinct());
                        var orderlists = new LinkOrder();
                        orderlists.OrderId = OrderIds;
                        if (OrderIds != "")
                        {
                            var maxItem =
                            _context.LinkOrder.OrderByDescending(i => i.LinkId).FirstOrDefault();
                            var newID = maxItem == null ? 1000 : maxItem.LinkId + 1;
                            orderlists.LinkId = newID;
                            this._context.LinkOrder.Add(orderlists);
                            this._context.SaveChanges();
                            OrderList.SuccessList.Add(orderlists);
                            listOrders.Clear();
                        }
                    
            }
            OrderList.FailedList.AddRange(failedOrders.Distinct());
            return OrderList;     
        
        }
 
    }
}