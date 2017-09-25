using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanUp.Models
{
    public class SongDbSet
    {
        public SongDbSet(int userId, int songId)
        {
            UserId = userId;
            SongId = songId;
        }

        [Key]
        public int UserId { get; set; }

        public int SongId { get; set; }
    }
}