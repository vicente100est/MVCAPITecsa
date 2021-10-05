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
    public class OperationController : ControllerBase
    {
        private string _connection = @"Server = tecnicaencolectores.com.mx; Database = tecsaoffice; Uid=tecnicae; Pwd = empresa21Tecs@; SslMode = none";
        [HttpGet]
        public IActionResult GetOperation()
        {
            try
            {
                IEnumerable<Models.Operation> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT * FROM operation";

                    lst = db.Query<Models.Operation>(sql);
                }

                return Ok(lst);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertOperation(Models.Operation model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO operation(name_operation,id_module)" +
                        " VALUES(@name_operation,@id_module)";
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
        public IActionResult EditOperation(Models.Operation model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE operation set name_operation=@name_operation,id_module=@id_module" +
                        " where id_operation=@id_operation";
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
        public IActionResult DeleteOperation(Models.Operation model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "delete from operation where id_operation=@id_operation";
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
