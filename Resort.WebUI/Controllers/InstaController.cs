using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaSharper.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resort.Application.Instagrams.Models;
using Resort.Persistence;
using Resort.Application.Instagrams.Commands;
using Resort.Common;
using InstaSharper.Classes;
using InstaSharper.API.Builder;
using InstaSharper.Logger;

namespace Resort.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstaController : BaseController
    {
        private readonly InstaContext _context;
        private static IInstaApi _instaApi;

        public InstaController(InstaContext context)
        {
            _context = context;

            if (_context.InstaModels.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.InstaModels.Add(new InstaModel { Caption = "Item1", ImageUrl="Please enter your image path" });
                _context.SaveChanges();
            }
        }
        // GET: api/Facebook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstaModel>>> GetInstaItem()
        {
            return await _context.InstaModels.ToListAsync();
        }
        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstaModel>> GetInstaItem(long id)
        {
            var instaItem = await _context.InstaModels.FindAsync(id);

            if (instaItem == null)
            {
                return NotFound();
            }

            return instaItem;
        }


        [HttpPost]
        public async Task<ActionResult<InstaModel>> PostFacebookItem(InstaModel item)
        {

            var result = Task.Run(MainAsync).GetAwaiter().GetResult();
            var samplesMap = new ChangeInstaCommand(_instaApi);
            string path = item.ImageUrl;


            string caption = item.Caption;

            Task.WaitAll(samplesMap.DoShow(path, caption));


            _context.InstaModels.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInstaItem), new { id = item.Id }, item);
        }


        public static async Task<bool> MainAsync()
        {
            try
            {
                Console.WriteLine("Starting demo of InstaSharper project{}");
                // create user session data and provide login details
                var userSession = new UserSessionData
                {
                    UserName = InstagramSetting.Username,
                    Password = InstagramSetting.Password
                };

                var delay = RequestDelay.FromSeconds(2, 2);
                // create new InstaApi instance using Builder
                _instaApi = InstaApiBuilder.CreateBuilder()
                    .SetUser(userSession)
                    .UseLogger(new DebugLogger(LogLevel.Exceptions)) // use logger for requests and debug messages
                    .SetRequestDelay(delay)
                    .Build();

                if (!_instaApi.IsUserAuthenticated)
                {
                    // login
                    Console.WriteLine($"Logging in as {userSession.UserName}");
                    delay.Disable();
                    var logInResult = await _instaApi.LoginAsync();
                    delay.Enable();
                    if (!logInResult.Succeeded)
                    {
                        Console.WriteLine($"Unable to login: {logInResult.Info.Message}");
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}
