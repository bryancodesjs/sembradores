using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CoinPayment;
using FlorApp.Models;


namespace FlorApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","SingIt");
            }
                
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Deposito()
        {

            return View();
        }

        public ActionResult Retiro()
        {

            return View();
        }

        public ActionResult Ajustes()
        {

            return View();
        }
        public ActionResult Transferencia()
        {

            return View();
        }

        public ActionResult Historial()
        {

            return View();
        }

        public ActionResult Landing()
        {

            return View();
        }
        public JsonResult Api(int Monto)
        {
            //SendTransaction _model = new SendTransaction();
            //_model.Amount = Monto;

        SortedList<string, string> parms = new SortedList<string, string>();

        parms["amount"] = Convert.ToString(Monto);
        parms["currency1"] = "USD"; 
         parms["currency2"] = "BTC";
        parms["buyer_email"] = Session["Email"].ToString();

        string s_privkey = "E05Aaf33825f499a702bb0143489F1dc62019109BF5b793Ff7D39823b11a0853";
         string s_pubkey = "0bac856fc9a519e1a82f8651d66371265e879310d0c1b11092b17d06e38a80cf";

         CoinPaymentAPI api = new CoinPaymentAPI(s_privkey, s_pubkey);

         var resp = api.CallAPI("create_transaction", parms);

            //CoinApi api = new CoinApi(s_privkey, s_pubkey);

            //var resp = await api.TransferAsync(_model);

         return Json(resp, JsonRequestBehavior.AllowGet);     
        }


    }
}