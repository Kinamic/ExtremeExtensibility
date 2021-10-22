using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryPersistence
{
    public class InMemoryUserRepository : IUserRepository
    {
        public string RepositoryName
        {
            get
            {
                return "Repositorio en Memoria";
            }
        }

        public List<string> GetUsers()
        {
            return new List<string>
            {
                "Cami",
                "Sofi",
                "Pola",
                "Adri"
            };
        }

        public override string ToString()
        {
            return RepositoryName;
        }
    }
}
