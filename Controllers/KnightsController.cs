using System;
using System.Collections.Generic;
using castle.Models;
using castle.Services;
using Microsoft.AspNetCore.Mvc;


namespace castle.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class KnightsController : ControllerBase
    {
        private readonly KnightsService _service;

        public KnightsController(KnightsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Knight>> GetAll()
        {
            try
            {
                IEnumerable<Knight> knights = _service.GetAll();
                return Ok(knights);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Knight> GetById(int id)
        {
            try
            {
                Knight knight = _service.GetById(id);
                return Ok(knight);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Knight> Create([FromBody] Knight newKnight)
        {
            try
            {
                Knight knight = _service.Create(newKnight);
                return Ok(knight);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult<Knight> Update(int id, [FromBody] Knight update)
        {
            try
            {
                update.Id = id;
                Knight updated = _service.Update(update);
                return Ok(updated);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<String> DeleteKnight(int id)
        {
            try
            {
                _service.DeleteKnight(id);
                return Ok("Knight has been killed (Deleted)");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }





    }
}