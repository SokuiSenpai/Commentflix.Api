using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentflix.Api.Database.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public long NetflixVideoId { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
