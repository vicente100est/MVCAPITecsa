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
    public class ModuleController : ControllerBase
    {
        private string _connection = @"Server = tecnicaencolectores.com.mx; Database = tecsaoffice; Uid=tecnicae; Pwd = empresa21Tecs@; SslMode = none";
        [HttpGet]
        public IActionResult GetModule()
        {
            try
            {
                IEnumerable<Models.Module> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT id_module,name_module FROM module";

                    lst = db.Query<Models.Module>(sql);
                }

                return Ok(lst);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertModule(Models.Module model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO module(name_module)" +
                        " VALUES(@name_module)";
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
        public IActionResult EditModule(Models.Module model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE module set name_module=@name_module" +
                        " where id_module=@id_module";
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
        public IActionResult DeleteModule(Models.Module model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "delete from module where id_module=@id_module";
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
