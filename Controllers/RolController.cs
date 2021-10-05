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
    public class RolController : ControllerBase
    {
        private string _connection = @"Server = tecnicaencolectores.com.mx; Database = tecsaoffice; Uid=tecnicae; Pwd = empresa21Tecs@; SslMode = none";
        [HttpGet]
        public IActionResult GetRol()
        {
            try
            {
                IEnumerable<Models.Rol> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT id_rol,name FROM rol";

                    lst = db.Query<Models.Rol>(sql);
                }

                return Ok(lst);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertRol(Models.Rol model)
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

        [HttpPut]
        public IActionResult EditRol(Models.Rol model)
        {
            try
            {
                int result = 0;
                using(var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE rol set name=@name" +
                        " where id_rol=@id_rol";
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
        public IActionResult DeleteRol(Models.Rol model)
        {
            try
            {
                int result = 0;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "delete from rol where id_rol=@id_rol";
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
