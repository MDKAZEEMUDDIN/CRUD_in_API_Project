using Employee.model;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Employee.Services;
using System.Runtime.ConstrainedExecution;

namespace Employee.Services
{
    public class ServiceMethod
    {
        SqlConnection con;
        public ServiceMethod(SqlConnection sqlConnection)
        {
            con = sqlConnection;
        }   

        public List<Emp_Model> GetAll()
        {
            List<Emp_Model> employees = new List<Emp_Model>();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Employee2";
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    employees.Add(new Emp_Model
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        EmployeeName = Convert.ToString(sdr["EmployeeName"]),
                        Age = Convert.ToInt32(sdr["Age"])
                    });
                }
                return employees;
            }
            finally
            {
                con.Close();
            }
        }
        public Boolean AddEmployee(Emp_Model employee)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //insert into Employee2(Id,EmployeeName,Age)values(2,'Kazeem',24);
                cmd.CommandText = "Insert into Employee2(ID,EmployeeName, Age) values(" + employee.Id + ",'" + employee.EmployeeName + "'," + employee.Age + ")";
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }

        }
        public Boolean UpdateEmployee(int id, Emp_Model employee)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Employee2 Set EmployeeName='" + employee.EmployeeName + "', Age=" + employee.Age + " Where(ID=" + id + ");";
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Boolean DeleteEmployee(int id)
        {
            try
            {
                 SqlCommand cmd = con.CreateCommand();
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = "Delete from Employee2 Where(ID=" + id + ");";
                 con.Open();
                 cmd.ExecuteNonQuery();
                
                  return true;

            }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
                 return false;
             }
            finally
            {
                con.Close();
            }
        }
    }



}
