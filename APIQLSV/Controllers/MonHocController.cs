using APIQLSV.Data;
using APIQLSV.Interfaces;
using APIQLSV.Models.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIQLSV.Controllers
{
    //[EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        IModelDAL<BaseMonHoc> db;
        public MonHocController()
        {
            db = new MonHocDAL();
        }
        // GET: api/<MonHocController>
        [HttpGet]
        public IList<BaseMonHoc> Get()
        {
            return db.GetAll();
        }

        // GET api/<MonHocController>/5
        [HttpGet("{id}")]
        public BaseMonHoc Get(int id)
        {
            return db.GetById(id);
        }
        [HttpGet("{page}", Name ="PagedListMonHoc")]
        public IList<BaseMonHoc> GetPage(int page=1, int pageSize=5)
        {
            if (page < 1)
                return new List<BaseMonHoc>();
            return db.GetPage(page, pageSize);
        }
        // POST api/<MonHocController>
        [HttpPost]
        public BaseMonHoc Post([FromBody] BaseMonHoc mh)
        {
            return db.Create(mh);
        }

        // PUT api/<MonHocController>/5
        [HttpPut]
        public BaseMonHoc Put([FromBody] BaseMonHoc mh)
        {

            return db.Update(mh);
        }

        // DELETE api/<MonHocController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            db.Delete(id);
            return StatusCode(202);
        }
        [Route("search{search}")]
        [HttpGet]
        public IActionResult Search(string search)
        {
            return Ok(db.Search(search));
        }
    }
}
