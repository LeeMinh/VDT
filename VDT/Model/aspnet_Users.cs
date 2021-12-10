using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDT
{
    public class aspnet_Users
    {

        private DBAccess db;
        //--------------------------------------------------------------------------
        public aspnet_Users()
        {
            db = new DBAccess();
        }
        //--------------------------------------------------------------------------
        ~aspnet_Users()
        {

        }
        //--------------------------------------------------------------------------
        public virtual void Dispose()
        {

        }
        //--------------------------------------------------------------------------
        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string LoweredUserName { get; set; }
        public string MobileAlias { get; set; }

        public bool IsAnonymous { get; set; }

        public DateTime LastActivityDate { get; set; }

        public virtual aspnet_Applications aspnet_Applications { get; set; }

        public virtual aspnet_Membership aspnet_Membership { get; set; }

        public virtual aspnet_Profile aspnet_Profile { get; set; }
    }

}
