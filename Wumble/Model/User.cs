using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumble.Model
{
    public class User
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Permission { get; set; }

        public string Children { get; set; }

        public int IdentityNumber { get; set; }
        public int latitude { get; set; }
        public int longitude { get; set; }

    }
}
