using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;
using WebBackend.Core.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebBackendDataAccess.Entities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Context { get; set; }
    }
}
