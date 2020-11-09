using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanteShopService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlanteShopApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlanteInlineController : ControllerBase
    {
        private static int PlanteIdGen
        {
            get
            {
                _planteId++;
                return _planteId;
            }
            set => _planteId = value;
        }

        private static int _planteId = 0;

        private static readonly List<Plante> planter = new List<Plante>()
        {
            new Plante(PlanteIdGen,"Rose", "Albertine",400,199),
            new Plante(PlanteIdGen, "Busk", "Aronia", 200, 169),
            new Plante(PlanteIdGen, "FrugtOgBaer", "AromaÆble", 350, 399),
            new Plante(PlanteIdGen, "Rhododendron", "Astrid", 40, 269),
            new Plante(PlanteIdGen, "Rose", "The dark lady", 100, 199)
        };

        // GET: api/<PlanteInlineController>
        [HttpGet]
        public IEnumerable<Plante> GetAllPlanter()
        {   
            return planter;
        }

        // GET api/<PlanteInlineController>/5
        [HttpGet("{id}")]
        public Plante GetPlanteByIdPlante(int id)
        {
            return planter.Find(plant => plant.PlanteId == id);
        }

        [HttpGet]
        [Route("ByType/{type}")]
        public IEnumerable<Plante> GetPlanterByType(string type)
        {
            return planter.FindAll(p => p.PlanteType.ToLower().Contains(type.ToLower()));
        }

        [HttpGet]
        [Route("ByName/{name}")]
        public Plante GetPlanteByName(string name)
        {
            return planter.Find(p => p.PlanteNavn.ToLower().Contains(name.ToLower()));
        }

        // POST api/<PlanteInlineController>
        [HttpPost]
        public void AddPlante([FromBody] Plante value)
        {
            value.PlanteId = PlanteIdGen;
            planter.Add(value);
        }

        // PUT api/<PlanteInlineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Plante value)
        {
            Plante plantToReplace = planter.Find(plant => plant.PlanteId == id);
            plantToReplace.MaksHoejde = value.MaksHoejde;
            plantToReplace.PlanteNavn = value.PlanteNavn;
            plantToReplace.PlanteType = value.PlanteType;
            plantToReplace.Price = value.Price;
        }

        // DELETE api/<PlanteInlineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Plante plantToDelete = planter.Find(p => p.PlanteId == id);
            planter.Remove(plantToDelete);
        }
    }
}
