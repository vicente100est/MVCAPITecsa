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
    public class WorkinTecsauserController : ControllerBase
    {
        private string _connection = @"Server = localhost; Database = tecsaoffice; Uid=root; Pwd = 12345678";
        [HttpGet]
        public IActionResult GetRol()
        {
            try
            {
                IEnumerable<Models.WorkinTecsauser> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT * FROM workin_tecsauser";

                    lst = db.Query<Models.WorkinTecsauser>(sql);
                }

                return Ok(lst);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertRol(Models.WorkinTecsauser model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO workin_tecsauser(id_work,id_user)" +
                        " VALUES(@id_work,@id_user)";
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
