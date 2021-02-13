using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Commentflix.Api.Requests
{
    [DataContract]
    public class CommentRequest
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string NetflixVideoId { get; set; }
    }
}
