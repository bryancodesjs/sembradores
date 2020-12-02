using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FlorApp.Controllers
{
    public class LoginController : Controller
    {
        
        string cadena = "Server=127.0.0.1; port= 3306; DataBase=flor; UserId=root; Password=";

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIt()
        {

            return View();
        }

        public ActionResult Acceder(string Email, string Clave)
        {
            string _User = string.Empty;

            MySqlConnection conn = null;
            conn = new MySqlConnection(cadena);

            MySqlDataReader rdr = null;

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("AccesoUsuario", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            var codigo = CodigoVerificacion();

            cmd.Parameters.Add(new MySqlParameter("@_email", Email));
            cmd.Parameters.Add(new MySqlParameter("@_clave", Clave));

            // execute the command
            rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            while (rdr.Read())
            {
                _User = rdr["Usuario"].ToString();
            }

            if (!string.IsNullOrEmpty(_User))
            {
                var user = rdr["usuario"];
                var mail = rdr["email"];
                var wallet = rdr["direccion_btc"];
                Session["Usuario"] = user;
                Session["Email"] = mail;
                Session["Wallet"] = wallet;

                conn.Close();

                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View("False", JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult Registro(string User, string Pass, string Email, string Direccion_btc)
        {
            MySqlConnection conn = null;
           
            conn = new MySqlConnection(cadena);
            conn.Open();
            
            MySqlCommand cmd = new MySqlCommand("RegistrarUsuario", conn);
            
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            var codigo = CodigoVerificacion();

            cmd.Parameters.Add(new MySqlParameter("@_usuario", User));
            cmd.Parameters.Add(new MySqlParameter("@_pass", Pass));
            cmd.Parameters.Add(new MySqlParameter("@_email", Email));
            cmd.Parameters.Add(new MySqlParameter("@_direccion_btc", Direccion_btc));
            cmd.Parameters.Add(new MySqlParameter("@_codigo_verificacion", codigo)); 

             // execute the command
             var resp = cmd.ExecuteNonQuery();
           
            conn.Close();

            if (resp > 0)
            {
                var respCorreo = EnviarCodigoPorCorreo(Email, codigo, User);

                if (respCorreo)
                {
                    return Json("Ok", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("False", JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }            

        }

        public ActionResult VerificarCodigo(string Usuario, int Codigo)
        {
            int codigoRecibido = 0;

            MySqlConnection conn = null;
            conn = new MySqlConnection(cadena);

            MySqlDataReader rdr = null;
            
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("VerificarCodigo", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            var codigo = CodigoVerificacion();

            cmd.Parameters.Add(new MySqlParameter("@_usuario", Usuario));
            cmd.Parameters.Add(new MySqlParameter("@_codigo", Codigo));
            
            // execute the command
            rdr = cmd.ExecuteReader();

            // iterate through results, printing each to console
            while (rdr.Read())
            {
                codigoRecibido = Convert.ToInt32(rdr["codigo_verificacion"]);               
            }
            

            if (codigoRecibido > 0)
            {
                var user = rdr["usuario"];
                var mail = rdr["email"];
                var wallet = rdr["direccion_btc"];
                Session["Usuario"] = user;
                Session["Email"] = mail;
                Session["Wallet"] = wallet;

                conn.Close();

                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }

        }
        public static int CodigoVerificacion()
        {
            Random random = new Random();
            int numero = 0;

            for (int i = 0; i < 10; i++)
            {
                numero += random.Next(1, 100000);
            }

            return numero;
        }

        public static bool EnviarCodigoPorCorreo(string Destinatario, int CodigoVerificacion, string Usuario)
        {
            bool enviado = false;

            MailMessage mail = new MailMessage();
            mail.To.Add(Destinatario);
            //mail.To.Add("Another Email ID where you wanna send same email");
            mail.From = new MailAddress("joseceeu@gmail.com");
            mail.Subject = "Hola "+ Usuario +", bienvenido a la familia! ";


            mail.Body = "Su Codigo de verificacion es " + CodigoVerificacion + " ";

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("joseceeu@gmail.com", "braudilio97");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;                   

            try
            {
                smtp.Send(mail);
                mail.Dispose();
                enviado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                enviado = false;
            }
            return enviado;
        }




    }
}