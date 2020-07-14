using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microex.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using server.Model;
using server.Services;

namespace server.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] List<LinkOrder> order)
        {
            try
            {
                var result = this._service.Save(order);
              
                StringBuilder str = new StringBuilder();
                if (result.SuccessList.Count != 0)
                {
                    foreach (var objSucess in result.SuccessList)
                    {
                        str.Append($"The Link id {objSucess.LinkId} has been created  for order ids {objSucess.OrderId} with same category.");
                     }
                }

                if (result.FailedList.Count != 0)
                {
                    foreach (var objFail in result.FailedList)
                    {
                        str.Append($"The Link id {objFail.LinkId} has been already exist for order ids {objFail.OrderId} .");
                        str.Append("\n");
                    }
                }

                return new ContentResult { Content = str.ToString(), StatusCode = 201 }; 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

      
    }
}