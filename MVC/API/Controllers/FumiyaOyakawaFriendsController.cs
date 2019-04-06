using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class FumiyaOyakawaFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/FumiyaOyakawaFriends
        public IQueryable<FumiyaOyakawaFriend> GetFumiyaOyakawaFriends()
        {
            return db.FumiyaOyakawaFriends;
        }

        // GET: api/FumiyaOyakawaFriends/5
        [ResponseType(typeof(FumiyaOyakawaFriend))]
        public IHttpActionResult GetFumiyaOyakawaFriend(int id)
        {
            FumiyaOyakawaFriend fumiyaOyakawaFriend = db.FumiyaOyakawaFriends.Find(id);
            if (fumiyaOyakawaFriend == null)
            {
                return NotFound();
            }

            return Ok(fumiyaOyakawaFriend);
        }

        // PUT: api/FumiyaOyakawaFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFumiyaOyakawaFriend(int id, FumiyaOyakawaFriend fumiyaOyakawaFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fumiyaOyakawaFriend.FriendId)
            {
                return BadRequest();
            }

            db.Entry(fumiyaOyakawaFriend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FumiyaOyakawaFriendExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FumiyaOyakawaFriends
        [ResponseType(typeof(FumiyaOyakawaFriend))]
        public IHttpActionResult PostFumiyaOyakawaFriend(FumiyaOyakawaFriend fumiyaOyakawaFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FumiyaOyakawaFriends.Add(fumiyaOyakawaFriend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fumiyaOyakawaFriend.FriendId }, fumiyaOyakawaFriend);
        }

        // DELETE: api/FumiyaOyakawaFriends/5
        [ResponseType(typeof(FumiyaOyakawaFriend))]
        public IHttpActionResult DeleteFumiyaOyakawaFriend(int id)
        {
            FumiyaOyakawaFriend fumiyaOyakawaFriend = db.FumiyaOyakawaFriends.Find(id);
            if (fumiyaOyakawaFriend == null)
            {
                return NotFound();
            }

            db.FumiyaOyakawaFriends.Remove(fumiyaOyakawaFriend);
            db.SaveChanges();

            return Ok(fumiyaOyakawaFriend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FumiyaOyakawaFriendExists(int id)
        {
            return db.FumiyaOyakawaFriends.Count(e => e.FriendId == id) > 0;
        }
    }
}