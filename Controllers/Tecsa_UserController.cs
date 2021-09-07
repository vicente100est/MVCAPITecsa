using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPITecsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tecsa_UserController : ControllerBase
    {
        private string _connection = @"Server = localhost; Database = tecsaoffice; Uid=root; Pwd = 12345678";

        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                IEnumerable<Models.TecsaUser> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT * FROM tecsauser";

                    lst = db.Query<Models.TecsaUser>(sql);
                }

                return Ok(lst);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertUser(Models.TecsaUser model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO tecsauser(name_user,email_user,password_user,date_user,id_rol)" +
                        " VALUES(@name_user,@email_user,@password_user,@date_user,@id_rol)";
                    result = db.Execute(sql, model);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditUser(Models.TecsaUser model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE tecsauser set name_user=@name_user,email_user=@email_user,password_user=@password_user,date_user=@date_user,id_rol=@id_rol" +
                        " where id_user=@id_user";
                    result = db.Execute(sql, model);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(Models.TecsaUser model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "delete from tecsauser where id_user=@id_user";
                    result = db.Execute(sql, model);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
