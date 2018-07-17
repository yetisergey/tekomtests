using Business;
using SocialNetwork.DTOs;
using System;
using System.Linq;
using System.Web.Http;

namespace SocialNetwork.Controllers
{
    public class FoodController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                using (var core = new Core())
                {
                    return Ok(core.GetFoods()
                        .Select(f => new CatalogDto()
                        {
                            Id = f.Id,
                            Value = f.Name
                        }).ToList());
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]FoodDto dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.Name))
                    throw new Exception("Некорректное поле Имя!");
                
                using (var core = new Core())
                {
                    return Ok(core.AddFood(dto.Name));
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}