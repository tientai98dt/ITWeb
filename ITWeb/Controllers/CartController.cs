using ITWeb.Models;
using ITWebDB.Concrete;
using ITWebDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITWeb.Controllers
{
    public class CartController : Controller
    {
        ITWebEntities db = new ITWebEntities();
        int dk,amount;

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ActionResult AddToCart(int productId, string returnUrl)
        {
            var sp = db.Products
                .FirstOrDefault(x => x.ProductId == productId);
            if (sp != null)
            {
                GetCart().AddItem(sp, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            var sp = db.Products
                .FirstOrDefault(x => x.ProductId == productId);
            if (sp != null)
            {
                GetCart().RemoveLine(sp);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult UpdateQuantity(int productId, int Quantity)
        {
            var cart = GetCart();
            var product = db.Products.FirstOrDefault(x => x.ProductId == productId);
            cart.UpdateProductByProductID(product, Quantity);
            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            var model = new CartIndexViewModel();
            model.Cart = GetCart();
            return View(model);
        }

        public ViewResult Checkout()
        {
            var model = new ShippingDetails();
            return View(model);
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            if (ModelState.IsValid)
            {
                //xử lý lưu đơn hàng
                //B1. lấy giỏ hàng
                var cart = GetCart();
                if (cart.Lines.Count == 0)
                {
                    ModelState.AddModelError("", "Vui lòng thêm sản phẩm");
                    return View(model);
                }
                ProcessOrder(model);
                if (dk != 0)
                {
                    cart.Clear();
                    return View("Completed");
                }
                else
                {
                    ModelState.AddModelError("", "Số lượng sản phẩm trong kho chỉ còn lại "+amount+ " vui lòng cập nhật lại số lượng trong giỏ hàng!");
                    return View(model);
                }
            }

            else
            {
                return View(model);
            }
        }

        private void ProcessOrder(ShippingDetails model)
        {
            var cart = GetCart();
            //1. Lưu Customer

            Customers customer = new Customers()
            {
                Address = model.Address,
                CustomerName = model.FullName,
                Email = model.Email,
                Phone = model.PhoneNumber,
            };
            db.Customers.Add(customer);

            //2. Lưu 1 hóa đơn cho ông Customer đó

            Orders order = new Orders()
            {
                CustomerId = customer.CustomerId,
                OrderDate = DateTime.Now,
            };
            db.Orders.Add(order);

            //3. Với các item mà ông ta mua, lưu chi tiết hóa đơn
            //cho hóa đơn đó
            OrderDetails orderDetail = null;
            foreach (var detail in cart.Lines)
            {
                orderDetail = new OrderDetails()
                {
                    OrderId = order.OrderId,
                    OrderPrice = detail.Product.Price,
                    ProductId = detail.Product.ProductId,
                    Quantity = detail.Quantity
                };
                db.OrderDetails.Add(orderDetail);
                var sp = db.Products.Where(x => x.ProductId == orderDetail.ProductId).ToList();

                foreach (var spp in sp)
                {
                    if (spp.ProductId == detail.Product.ProductId)
                    {
                        if (spp.Amount >= detail.Quantity)
                        {
                            spp.Amount = spp.Amount - detail.Quantity;
                            dk = 1;
                            db.SaveChanges();
                        }
                        else
                        {
                            dk = 0;
                            amount = spp.Amount;
                        }
                    }
                }
            }
        }

    }
}