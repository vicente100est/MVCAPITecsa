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
    public class RolOperationController : ControllerBase
    {
        private string _connection = @"Server = localhost; Database = tecsaoffice; Uid=root; Pwd = 12345678";
        [HttpGet]
        public IActionResult GetRolOperation()
        {
            try
            {
                IEnumerable<Models.RolOperation> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT * FROM rol_operation";

                    lst = db.Query<Models.RolOperation>(sql);
                }

                return Ok(lst);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertRolOperation(Models.RolOperation model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO rol_operation(id_rol, id_operation)" +
                        " VALUES(@id_rol, @id_operation)";
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
        public IActionResult EditRolOperation(Models.RolOperation model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE rol_operation set id_rol=@id_rol,id_operation=@id_operation" +
                        " where id_up=@id_up";
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
        public IActionResult DeleteRolOperation(Models.RolOperation model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "delete from rol_operation where id_up=@id_up";
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
