using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefa3.Domain.Interfaces.Service;
using Tarefa3.Domain.Models;

namespace Tarefa3.Application.Services
{
    public class PersonService : IPersonService
    {
        public List<Person> GetAll()
        {
            return new List<Person>
            {
                new Person { Id = 1, Name = "Leonardo Tristao", Age = 19, Cep = "13024-050" },
                new Person { Id = 2, Name = "Hyan Schibelsky", Age = 18, Cep = "10000-003"},
                new Person { Id = 3, Name = "Kairos Murilo", Age = 18, Cep = "" },
                new Person { Id = 4, Name = "Andre Barros", Age = 19}
            };
        }
    }
}
