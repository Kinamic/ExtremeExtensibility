using Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InFilePersistence
{

    public class InFileUserRepository : IUserRepository
    {
        public string RepositoryName => "Repositorio en Archivo";

        public List<string> GetUsers()
        {
            var users = File.ReadAllLines("usuarios.txt");
            return users.ToList();
        }

        public override string ToString()
        {
            return RepositoryName;
        }
    }
}
