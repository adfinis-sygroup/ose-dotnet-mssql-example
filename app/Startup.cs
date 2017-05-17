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
      "Server=10.0.0.7;Database=demo;User Id=SA;Password=zVvbPSB5uUqm";
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
            result += "<table>";
            result += string.Format("<tr><td>{0}</td> <td>{1}</td> <td>{2}</td><td>:-)</td></tr>",
                reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            result += "</table>";
          }
        }
      }

      context.Response.ContentType = "text/html";
      return context.Response.WriteAsync(result);
      });
    }
  }
