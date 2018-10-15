using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Repositories
{
    public class BaseRepository
    {
        private readonly TodoContext _context;

        public BaseRepository(TodoContext context)
        {
            _context = context;
        }
    }
}
