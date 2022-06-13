using APIQLSV.Models.Base;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ISession = NHibernate.ISession;
using APIQLSV.Services;
using System.Net;
using APIQLSV.Interfaces;
using APIQLSV.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIQLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        IModelDAL<SinhVien> db;
        public SinhVienController()
        {
            db = new SinhVienDAL();
        }
        // GET: api/<SinhVienController>
        [HttpGet]
        public List<SinhVien> Get()
        {
            return db.GetAll();
        }

        // GET api/<SinhVienController>/id
        [HttpGet("{id}")]
        public SinhVien Get(int id)
        {
            return db.GetById(id);
        }
        [Route("/api/SinhVien/page")]
        [HttpGet]
        public PagedResult Get([FromQuery] int page, int pageSize)
        {
            var result = new PagedResult();
            if (page < 1)
                result.list = new List<SinhVien>().ToList();
            else
                result.list = db.GetPage(page, pageSize).ToList();
            result.total = db.GetAll().Count();
            result.pageSize = 10;
            result.page=page;
            return result;
        }

        // POST api/<SinhVienController>
        [HttpPost]
        public SinhVien Post([FromBody] SinhVien sv)
        {

            return db.Create(sv);
        }

        // PUT api/<SinhVienController>/5
        [HttpPut]
        public SinhVien Put([FromBody] SinhVien sv)
        {
            return db.Update(sv);
        }

        // DELETE api/<SinhVienController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Delete(id);
            //return Ok;
        }
    }
}
