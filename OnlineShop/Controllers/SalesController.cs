using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Facade.Interfaces;
using OnlineShop.Facade.Models;

namespace OnlineShop.Controllers
{
    [Produces("application/json")]
    public class SalesController : Controller
    {
        private readonly ISalesFacade _salesFacade;
        public SalesController(ISalesFacade salesFacade)
        {
            _salesFacade = salesFacade;
        }

        [HttpPost]
        [Route("api/sales/viewCartItems")]
        public ActionResult viewCartItems(Guid cartKey)
        {
            DetailedCartItemsResponse cartItemsResponse = _salesFacade.GetAllDetailedCartItems(cartKey);
            return Ok(cartItemsResponse);
        }
        [HttpPost]
        [Route("api/sales/getAllCartItems")]
        public ActionResult GetAllCartItems(Guid cartKey)
        {
            CartItemsResponse cartItemsResponse = _salesFacade.GetAllCartItems(cartKey);
            return Ok(cartItemsResponse);
        }
        [HttpPost]
        [Route("api/sales/addToCart")]
        public ActionResult AddToCart(CartItemParams toCartParams)
        {
            CartItemsResponse cartItemsResponse = _salesFacade.AddToCart(toCartParams);
            return Ok(cartItemsResponse);
        }
        [HttpPost]
        [Route("api/sales/removeFromCart")]
        public ActionResult RemoveFromCart(CartItemParams toCartParams)
        {
            CartItemsResponse cartItemsResponse = _salesFacade.RemoveFromCart(toCartParams);
            return Ok(cartItemsResponse);
        }
        [HttpPost]
        [Route("api/sales/placeOrder")]
        public ActionResult PlaceOrder(OrderParams orderParams)
        {
            OrderResponse orderResponse = _salesFacade.PlaceOrder(orderParams);
            return Ok(orderResponse);
        }
    }
}