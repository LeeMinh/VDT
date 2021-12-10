using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDT
{
    public class aspnet_Profile
    {

        private DBAccess db;
        //--------------------------------------------------------------------------
        public aspnet_Profile()
        {
            db = new DBAccess();
        }
        //--------------------------------------------------------------------------
        ~aspnet_Profile()
        {

        }
        //--------------------------------------------------------------------------
        public virtual void Dispose()
        {

        }
        //--------------------------------------------------------------------------
        public Guid UserId { get; set; }

        public string PropertyNames { get; set; }

        public string PropertyValuesString { get; set; }
        public byte[] PropertyValuesBinary { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }
    }

}
