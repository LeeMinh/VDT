using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDT
{
    public class aspnet_Membership
    {

        private DBAccess db;
        //--------------------------------------------------------------------------
        public aspnet_Membership()
        {
            db = new DBAccess();
        }
        //--------------------------------------------------------------------------
        ~aspnet_Membership()
        {

        }
        //--------------------------------------------------------------------------
        public virtual void Dispose()
        {

        }
        //--------------------------------------------------------------------------

        public Guid ApplicationId { get; set; }

        public Guid UserId { get; set; }

        public string Password { get; set; }

        public int PasswordFormat { get; set; }

        public string PasswordSalt { get; set; }

        public string MobilePIN { get; set; }

        public string Email { get; set; }

        public string LoweredEmail { get; set; }

        public string PasswordQuestion { get; set; }

        public string PasswordAnswer { get; set; }

        public bool IsApproved { get; set; }

        public bool IsLockedOut { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime LastPasswordChangedDate { get; set; }

        public DateTime LastLockoutDate { get; set; }

        public int FailedPasswordAttemptCount { get; set; }

        public DateTime FailedPasswordAttemptWindowStart { get; set; }

        public int FailedPasswordAnswerAttemptCount { get; set; }

        public DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }

        public string Comment { get; set; }

        public virtual aspnet_Applications aspnet_Applications { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }
    }

}