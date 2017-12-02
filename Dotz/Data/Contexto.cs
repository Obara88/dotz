using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Dotz.Model;

namespace Dotz.Data
{
    public class Contexto
    {
        private readonly IMongoDatabase _database = null;

        public Contexto(IOptions<Configuracao> configuracao)
        {
            var mongoCliente = new MongoClient(configuracao.Value.ConnectionString);
            if (mongoCliente != null)
            {
                _database = mongoCliente.GetDatabase(configuracao.Value.Database);
            }

        }

        public IMongoCollection<Usuario> Usuarios
        {
            get
            {
                return _database.GetCollection<Usuario>("Usuario");
            }
        }


        public IMongoCollection<Extrato> Extratos
        {
            get
            {
                return _database.GetCollection<Extrato>("Extrato");
            }
        }

    }
}
