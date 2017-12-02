using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Model
{
    [BsonIgnoreExtraElements]
    public class Extrato
    {
        public string Email { get; set; }
        public Guid CompraId { get; set; }
        public int Pontos { get; set; }
    }
}
