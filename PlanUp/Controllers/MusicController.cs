using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNet.Identity;
using PlanUp.Models;


namespace PlanUp.Controllers
{
    public class MusicController : Controller
    {
        private MusicSetupController msc;
        private readonly ApplicationDbContext _context;

        public MusicController()
        {
            _context = new ApplicationDbContext();
        }
       
        public async Task<ActionResult> Index()
        {
            try
            {
                var query = Request["genre"];
                msc = new MusicSetupController(query);
                Song[] playlist;
                while (true)
                {
                    var task = msc.RunAsync();
                    playlist = await task;
                    if (isValidPlayList(playlist))
                    {
                        addToDB(playlist);
                        return View(playlist);
                    }
                }
                return null;

            }
            catch (AggregateException ex)
            {
                 Console.WriteLine("Error: " + ex.Message);
            }
            return Redirect("Index");
        }

        private bool isValidPlayList(Song[] playlist)
        {
            //var user = _context.Users.Single(u => u.Id == User.Identity.GetUserId());
            //var songs = _context.SongDbSet.Where(s => s.UserId == int.Parse(user.Id));
            var songs = _context.SongDbSet;
            if (songs.Any())
            {
                foreach (var song in songs)
                {
                    foreach (var item in playlist)
                    {
                        if (song.SongId == Int32.Parse(item.SongId))
                            return false;
                    }
                }
            }
            return true;
        }

        private void addToDB(Song[] playlist)
        {
            //var userId = Int32.Parse(User.Identity.GetUserId());
            var userId = 1;
            foreach (var item in playlist)
            {
                int songId;
                int.TryParse(item.SongId, out songId);
                var songDb = new SongDbSet(userId, songId);
                _context.SongDbSet.Add(songDb);
                _context.SaveChanges();
            }
        }
    }
        
}
