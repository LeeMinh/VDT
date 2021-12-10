using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDT
{
    public class aspnet_Applications
    {

        private DBAccess db;
        //--------------------------------------------------------------------------
        public aspnet_Applications()
        {
            db = new DBAccess();
            aspnet_Membership = new HashSet<aspnet_Membership>();
            aspnet_Users = new HashSet<aspnet_Users>();
        }
        //--------------------------------------------------------------------------
        ~aspnet_Applications()
        {

        }
        //--------------------------------------------------------------------------
        public virtual void Dispose()
        {

        }
        //--------------------------------------------------------------------------
       
        public string ApplicationName { get; set; }

        public string LoweredApplicationName { get; set; }

        public Guid ApplicationId { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnet_Membership> aspnet_Membership { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnet_Users> aspnet_Users { get; set; }
    }

}
