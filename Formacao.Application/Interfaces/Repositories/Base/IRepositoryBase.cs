using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task SaveChangesAsync();
    }
}
