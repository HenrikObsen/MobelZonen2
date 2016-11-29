using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoMZ2;

namespace RepoMZ2.Factories
{
    public class BrugerFac : AutoFac<Bruger>
    {

        public Bruger Login(string email, string adgangskode)
        {
            Bruger b = new Bruger();
            Mapper<Bruger> mapper = new Mapper<Bruger>();

            using (var CMD = new SqlCommand("select * from Bruger where Email=@email and Adgangskode=@adgangskode", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@email", email);
                CMD.Parameters.AddWithValue("@adgangskode", adgangskode);

                var r = CMD.ExecuteReader();

                if (r.Read())
                {
                    b = mapper.Map(r);
                }

            }

            return b;

        }

    }
}
