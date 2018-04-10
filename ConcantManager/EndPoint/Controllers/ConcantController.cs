using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Business;
using Business.Interfaces;

namespace EndPoint.Controllers
{
    [Route("api/[controller]")]
    public class ConcantController : Controller
    {
        private readonly IRepository<Concant> _concantRepository;        
        
        public ConcantController(IRepository<Concant> concantRepository)
        {
            _concantRepository = concantRepository ;
        }
       // GET api/concant
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_concantRepository.All());
        }

        // GET api/concant/5
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var concant = _concantRepository.Where(s => s.ConcantId.Equals(id)).SingleOrDefault();
            if (concant == null) return NotFound();

            return Ok(concant);
        }

        // POST api/concant
        [HttpPost]
        public IActionResult Post([FromBody]Concant concant)
        {
            if (!ModelState.IsValid || concant == null) return BadRequest();

            if (_concantRepository.Add(concant))
                return Ok(concant);

            return BadRequest();
        }

        // PUT api/concant/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody]Concant concant)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid || concant == null) return BadRequest();

            var oldConcant = _concantRepository.Where(s => s.ConcantId.Equals(id)).SingleOrDefault();
            if (oldConcant == null) return NotFound();

            concant.ConcantId = oldConcant.ConcantId;
            if (_concantRepository.Update(concant))
                return Ok(concant);
            return BadRequest();
        }

        // DELETE api/concant/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var concant = _concantRepository.Where(s => s.ConcantId.Equals(id)).SingleOrDefault();
            if (concant == null) return NotFound();

            if (_concantRepository.Delete(concant))
                return Ok(concant);
            return BadRequest();
        }
    }
}
