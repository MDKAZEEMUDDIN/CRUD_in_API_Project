using Microsoft.AspNetCore.Mvc;
using Employee.model;
using System.Data.SqlClient;
using System.Net.WebSockets;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data;
using Employee.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo_Core_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IConfiguration _configuration { get; }
        SqlConnection con;
        ServiceMethod ser;
        
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
             con = new SqlConnection(_configuration.GetConnectionString("Company"));
                     ser= new ServiceMethod(con);
        }
            
        [HttpGet]
        public JsonResult GetAllEmployee()
        {
            try
            {
                return new JsonResult(ser.GetAll());
            }
           catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost]
        public Boolean AddEmployee(Emp_Model employee)
        {
            try 
            {
               //ser.AddEmployee(employee);   
                return ser.AddEmployee(employee);
            }
            
            finally
            {
                con.Close();
            }
        }
        [HttpPut]
        public Boolean UpdateEmployee(int id, Emp_Model employee)
        {
            try
            {
              return ser.UpdateEmployee(id, employee);
              return true;
            }
           
            finally
            {
                con.Close();
            }
        }
        [HttpDelete]
        public Boolean DeleteEmployee(int id)
        {
            try
            {
               ser.DeleteEmployee(id);
               return true;
               
            }
          
            finally
            {
                con.Close();
            }
        }
    }
}
