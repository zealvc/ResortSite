using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resort.Application.Facebooks.Commands;
using Resort.Application.Facebooks.Models;
using Resort.Common;
using Resort.Persistence;

namespace Resort.WebUI.Controllers
{
    
    public class FacebookController : BaseController
    {
        private readonly FacebookContext _context;

        public FacebookController(FacebookContext context)
        {
            _context = context;

            if (_context.FacebookModels.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.FacebookModels.Add(new FacebookModel { Text = "Item1", ImageUrl = "This is the url of image" });
                _context.SaveChanges();
            }
        }
        // GET: api/Facebook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacebookModel>>> GetFacebookItem()
        {
            return await _context.FacebookModels.ToListAsync();
        }
        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacebookModel>> GetFacebookItem(long id)
        {
            var facebookItem = await _context.FacebookModels.FindAsync(id);

            if (facebookItem == null)
            {
                return NotFound();
            }

            return facebookItem;
        }


        [HttpPost]
        public async Task<ActionResult<FacebookModel>> PostFacebookItem(FacebookModel item)
        {
            string text = item.Text;
            string imageurl = item.ImageUrl;
            ChangeFacebookCommand facebook = new ChangeFacebookCommand(FacebookSetting.AccessToken, FacebookSetting.PageId);
            facebook.PublishToFacebook(text, imageurl);

            _context.FacebookModels.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFacebookItem), new { id = item.Id }, item);
        }
    }
}
