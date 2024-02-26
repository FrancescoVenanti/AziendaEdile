using AziendaEdile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AziendaEdile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbEdile"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            List<Dipendente> dipendenti = new List<Dipendente>();

            try
            {
                conn.Open();

                string query = "SELECT * FROM Dipendenti";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Dipendente dipendente = new Dipendente();
                    dipendente.IDDipendente = Convert.ToInt32(reader["IDDipendente"]);
                    dipendente.NomeDipendente = reader["NomeDipendente"].ToString();
                    dipendente.CognomeDipendente = reader["CognomeDipendente"].ToString();
                    dipendente.Indirizzo = reader["Indirizzo"].ToString();
                    dipendente.CodFiscale = reader["CodFiscale"].ToString();
                    dipendente.Sposato = Convert.ToBoolean(reader["Sposato"]);
                    dipendente.FigliCarico = Convert.ToInt32(reader["FigliCarico"]);
                    dipendente.Mansione = reader["Mansione"].ToString();

                    dipendenti.Add(dipendente);

                }

            }
            catch (Exception ex)
            {
                Response.Write($"Errore durante il recupero dei dati: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }

            return View(dipendenti);
        }

        public ActionResult InserisciDipendente()
        {
            return View();
        }


        [HttpPost]
        public ActionResult InserisciDipendente(Dipendente dipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbEdile"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query =
                    "INSERT INTO Dipendenti (NomeDipendente,CognomeDipendente,Indirizzo,CodFiscale,Mansione,Sposato,FigliCarico) " +
                    "VALUES (@NomeDipendente,@CognomeDipendente,@Indirizzo,@CodFiscale,@Mansione,@Sposato,@FigliCarico) ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NomeDipendente", dipendente.NomeDipendente);
                cmd.Parameters.AddWithValue("@CognomeDipendente", dipendente.CognomeDipendente);
                cmd.Parameters.AddWithValue("@Indirizzo", dipendente.Indirizzo);
                cmd.Parameters.AddWithValue("@CodFiscale", dipendente.CodFiscale);
                cmd.Parameters.AddWithValue("@Mansione", dipendente.Mansione);
                cmd.Parameters.AddWithValue("@Sposato", dipendente.Sposato);
                cmd.Parameters.AddWithValue("@FigliCarico", dipendente.FigliCarico);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Response.Write("aaaaaaaaaaaa" +ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return View();
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
        
    }
}