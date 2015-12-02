using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ioc.Core.Entities;

namespace Ioc.Data.Redis
{
    public interface IBlogRepository:IBaseRepository<BlogEntity>
    {

    }
}
