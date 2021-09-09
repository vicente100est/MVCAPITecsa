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
    public class RollCallController : ControllerBase
    {
        private string _connection = @"Server = localhost; Database = tecsaoffice; Uid=root; Pwd = 12345678";
        [HttpGet]
        public IActionResult GetRollCall()
        {
            try
            {
                IEnumerable<Models.RollCall> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT id_rol,name FROM rol";

                    lst = db.Query<Models.RollCall>(sql);
                }

                return Ok(lst);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertRollCall(Models.RollCall model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO rol(name)" +
                        " VALUES(@name)";
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
