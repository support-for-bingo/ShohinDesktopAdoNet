using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShohinDesktopAdoNet.Models.Repositorys
{
    public class DbConfig
    {
        public const string ConnectionString = "Data Source=(local)\\SQLEXPRESS;Integrated Security=true;Initial Catalog=AdoNetSample;Encrypt=false";
        public const string ConnectionStringOracle = "Data Source=localhost:1521/XEPDB1;User id=ORIGIN;Password=originpassword;";
    }
}