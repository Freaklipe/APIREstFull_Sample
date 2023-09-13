using APIREstFull_Sample.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIREstFull_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private static List<Item> items = new ();

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            items.Add (item);
            return Ok();
        }

        [HttpPut("{_id}")]
        public IActionResult Put(int _id, [FromBody] Item item) 
        {
            int index = items.FindIndex(i=> i.Id == _id);
            if (index != -1)
            {
                items[index] = item;
                return Ok();
            } else
                return NotFound();
        }

        [HttpDelete("{_id}")]
        public IActionResult Delete(int _id)
        {
            int index = items.FindIndex(i => i.Id == _id);
            if (index != -1)
            {
                items.RemoveAt(index);
                return Ok();
            }
            else
                return NotFound();
        }

    }
}
