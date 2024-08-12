using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;




namespace CRMAPP.Pages.Customers

{
    public class Delete : PageModel
    {
                public void OnGet(int id)
        {
            deleteCustomer(id);
            Response.Redirect("/Customers/Index");
        }

        public void OnPost(int id){
            deleteCustomer(id);
            Response.Redirect("/Customers/Index");

        }

        private void deleteCustomer(int id){

            try {
                string connectionString = "Server=VALENTINA\\SQLEXPRESS;Database=FirstConnection;Trusted_Connection=True;TrustServerCertificate=True;";
                 
                using (SqlConnection connection = new SqlConnection(connectionString))

                { 
                
                   connection.Open();

                   string sql = "DELETE FROM customers WHERE id=@id";
                   using (SqlCommand command = new SqlCommand(sql, connection)){
                        command.Parameters.AddWithValue("@id",id);
                        command.ExecuteNonQuery();
                    }
                 }
            }
            catch(Exception ex){
                Console.WriteLine("Cannot delete customer: "+ ex.Message);
            }

        }






        

    }
}