#nullable enable
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using dotnetapp.Models;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("user/signup")]
        public IActionResult saveUser(UserModel users)
        {
            string check = @"select email from UserModel where email=@email";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("myconnstring");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(check, myCon))
                {
                    myCommand.Parameters.AddWithValue("@email", users.email);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            if (table != null && table.Rows.Count > 0)
            {
                return Conflict(new { value = false, message = "Email already exists." });
            }
            string query = @"insert into dbo.UserModel (username, email, mobileNumber, password, userRole) values (@username, @email, @mobileNumber, @password, @userRole)";
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@username", users.username);
                    myCommand.Parameters.AddWithValue("@email", users.email);
                    myCommand.Parameters.AddWithValue("@mobileNumber", users.mobileNumber);
                    myCommand.Parameters.AddWithValue("@password", users.password);
                    myCommand.Parameters.AddWithValue("@userRole", users.userRole);
                    myCommand.ExecuteNonQuery();
                }
            }
            return Created(new Uri(Request.Path, UriKind.RelativeOrAbsolute), new { value = true, message = "Registered Successfully" });
        }

        [HttpPost]
        [Route("user/login")]
        public IActionResult isUserPresent([FromBody] LoginModel login)
        {
            string query = @"select email,password from dbo.UserModel where email=@email and password=@password";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("myconnstring");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@email", login.email);
                    myCommand.Parameters.AddWithValue("@password", login.password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            if (table != null && table.Rows.Count > 0)
            {
                string q2 = @"select userRole from UserModel where email=@email";
                DataTable t2 = new DataTable();
                string s = "";
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(q2, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@email", login.email);
                        myReader = myCommand.ExecuteReader();
                        t2.Load(myReader);
                        foreach (DataRow row in t2.Rows)
                        {
                            s = row["userRole"].ToString();
                        }
                        myReader.Close();
                        myCon.Close();
                    }
                }
                return Ok(new { success = true, s = s });
            }
            else
                return NotFound(new { success = false, message = "Invalid credentials." });
        }

        [HttpDelete]
        [Route("user/logout")]
        public IActionResult Logout()
        {
            string q = @"delete from dbo.LoginModel";
            string sqlDataSource = _configuration.GetConnectionString("myconnstring");
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(q, myCon))
                {
                    int myReader = myCommand.ExecuteNonQuery();
                    if (myReader == 0)
                        return Ok(new { value = "Logged Out Successfully" });
                }
            }
            return Ok(new { value = "Logged Out Successfully" });
        }
    }
}
