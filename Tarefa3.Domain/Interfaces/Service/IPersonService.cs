using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefa3.Domain.Models;

namespace Tarefa3.Domain.Interfaces.Service
{
    public interface IPersonService
    {
        List<Person> GetAll();
    }
}
