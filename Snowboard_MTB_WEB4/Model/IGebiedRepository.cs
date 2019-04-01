using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Model
{
    public interface IGebiedRepository
    {

        IEnumerable<Gebied> GetAll();
        Gebied GetById(int id);
    }
}
