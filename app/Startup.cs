using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Data.SqlClient;

public class Startup
{
  public void Configure(IApplicationBuilder app)
  {
    app.Run(context =>
    {
       string connectionString =
            "Server=52.174.147.25;Database=demo;User Id=SA;Password=zVvbPSB5uUqm";
        String result="";
        //
        // In a using statement, acquire the SqlConnection as a resource.
        //
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            //
            // Open the SqlConnection.
            //
            con.Open();
            //
            // The following code uses an SqlCommand based on the SqlConnection.
            //
            //string result = "";
            using (SqlCommand command = new SqlCommand("SELECT * FROM customers;", con))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result += string.Format("{0} {1} {2}<br>",
                        reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }
        }

      return context.Response.WriteAsync(result);
    });
  }
}
