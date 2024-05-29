using ProiectPAW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ProiectPAW.Services.Interfaces;
using ProiectPAW.Services;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ProiectPAW.Controllers
{

    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderProductService _orderProductService;
        private readonly IUserInfoService _userInfoService;
        private readonly IUserService _userService;


        public HomeController(IProductService productService,  IOrderService orderService,  IOrderProductService orderProductService, IUserInfoService userInfoService, IUserService userService)
        {
            _productService = productService;
            _orderService = orderService;
            _orderProductService = orderProductService;
            _userInfoService = userInfoService;
            _userService = userService;

        }


        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult Checkout(int id,double pretTotal)
        {
            var order = _orderService.GetOrderById(id);
            ViewBag.pret = pretTotal;
            ViewData["UserID"] = new SelectList(_userService.GetUsers(), "Id", "Id", order.userID);
            return View(order);
        }
        // GET: Orders/Edit/5
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(int id, double pretTotal, [Bind("orderID,dateOfPlacement,status,mesaj,telefon,adresa,TotalPrice,userID")] Order order)
        {
            if(order != _orderService.GetOrderById(id))
            {

            }
            if (ModelState.IsValid)
            {
                try
                {
                    order.status = "Placed";
                    order.dateOfPlacement = DateTime.Now;
                    _orderService.UpdateOrder(order);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_userService.GetUsers(), "Id", "Id", order.userID);
            return View(order);
        }

        [Route("Home/Contact")]
        [Authorize]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Home/Cos")]
        public IActionResult Cos(string id)
        {
            var order = _orderService.GetActiveOrderByUserId(id);
            ViewBag.Order = order;

            if(order != null)
            {
                var orderProduct = _orderProductService.GetOrderProductsByOrderId(order.orderID);
                ViewBag.OrderProduct = orderProduct;
                ViewBag.Product = _productService.GetProducts();
            }

            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult CosCreate(string id,[Bind("orderID,dateOfPlacement,status,TotalPrice,userID")] Order order)
        {
            
            if (ModelState.IsValid)
            {
                order.userID = id;
                order.status = "Active";
                // Save the order to the database
                _orderService.CreateOrder(order);

                return RedirectToAction(nameof(Index));
            }

            // If ModelState is not valid, reload the view with appropriate data
            ViewData["userID"] = new SelectList(_userService.GetUsers(), "Id", "Id", order.userID);
            return View(order);
        }

        public IActionResult CreareProfil()
        {
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View();
        }

        // POST: UserInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreareProfil(string id, [Bind("UserInfoID,Username,ProfileImage,UserId")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.UserId = id;
                _userInfoService.CreateUserInfo(userInfo);
 
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", userInfo.UserId);
            return View(userInfo);
        }

        [Route("Home/ListaProdus")]
        public IActionResult ListaProdus()
        {

            return View(_productService.GetProducts());
        }

        [Route("Home/Buchete")]
        public IActionResult Buchete()
        {
            return View(_productService.GetProducts());
        }

        [Route("Home/Aranjamente")]
        public IActionResult Aranjamente()
        {
            return View(_productService.GetProducts());
        }

        [Route("Home/Criogenati")]
        public IActionResult Criogenati()
        {
            return View(_productService.GetProducts());
        }

        [Route("Home/Suculente")]
        public IActionResult Suculente()
        {
            return View(_productService.GetProducts());
        }

        [Route("Home/Produs")]
        public IActionResult Produs(int id)
        {    
            ViewBag.Order = _orderService.GetOrders();
            ViewBag.Id = id;
            ViewBag.Product = _productService.GetProductById(id); 
            ViewData["OrderID"] = new SelectList(_orderService.GetOrders(), "orderID", "orderID");
            ViewData["ProductID"] = new SelectList(_productService.GetProducts(), "productID", "productID");
            return View();
        }

        [Route("Home/ConectareSucces")]

        public IActionResult ConectareSucces()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToOrder(int id, string userId,[Bind("OrderProductID,OrderID,Quantity,ProductID")] OrderProduct orderProduct)
        {
            if (ModelState.IsValid)
            {
                var order = _orderService.GetActiveOrderByUserId(userId);
                orderProduct.ProductID = id;
                orderProduct.OrderID = order.orderID;

                _orderProductService.CreateOrderProduct(orderProduct);
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_orderService.GetOrders(), "orderID", "orderID", orderProduct.OrderID);
            ViewData["ProductID"] = new SelectList(_productService.GetProducts(), "productID", "productID", orderProduct.ProductID);
            return View(orderProduct);
        }

         

        [Route("Home/Profil")]
        public IActionResult Profil(string id)
        {
            var user = _userInfoService.GetUserInfoByUserId(id);
            return View(user);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
