using Snowboard_MTB_WEB4.Data;
using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data
{
    public class SnowbreakDataInitializer
    {
        private SnowbreakDbContext _context;

        public SnowbreakDataInitializer(SnowbreakDbContext context)
        {
            _context = context;
        }

        public void InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                Gebied gebied = new Gebied("Val Thorens", "Frankrijk", "45.292165498 6.574664368", 86, 2300);
            }
        }

    }
}
