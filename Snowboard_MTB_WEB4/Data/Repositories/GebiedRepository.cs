﻿using Microsoft.EntityFrameworkCore;
using Snowboard_MTB_WEB4.Data;
using Snowboard_MTB_WEB4.Model;
using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data.Repositories
{
    public class GebiedRepository : IGebiedRepository
    {
        private DbSet<Gebied> _gebieden;
        private SnowbreakDbContext _context;

        public GebiedRepository(SnowbreakDbContext context)
        {
            _context = context;
            _gebieden = context.Gebieden;
        }

        public void Add(Gebied gebied)
        {
            _gebieden.Add(gebied);
        }

        public void Delete(Gebied gebied)
        {
            _gebieden.Remove(gebied);
        }

        public IEnumerable<Gebied> GetAll()
        {
            return _gebieden.ToList();
        }

        public Gebied GetById(int id)
        {
            return _gebieden.FirstOrDefault(gebied => gebied.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Gebied gebied)
        {
            _gebieden.Update(gebied);
        }
    }
}
