using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Profile;
using System.Web.Security;

namespace VDT
{
    public class userprofile : ProfileBase
    {
        public static userprofile CurrentUser
        {
            get
            {
                var user = Membership.GetUser();
                if (user != null)
                    return (userprofile)
                           ProfileBase.Create(Membership.GetUser().UserName);
                else return null;
            }
        }

        public static userprofile GetUser(string userName)
        {
            return (userprofile)
                           ProfileBase.Create(userName);
        }
        public static userprofile GetUser(Guid userID)
        {
            var users = Membership.GetAllUsers();
            MembershipUser user = null;
            foreach (MembershipUser item in users)
            {
                if (item.ProviderUserKey.ToString().Equals(userID.ToString()))
                {
                    user = item;
                    break;
                }
            }
            if (user != null)
                return (userprofile)
                               ProfileBase.Create(user.UserName);
            else return (userprofile)ProfileBase.Create(string.Empty);
        }
        public string FullName
        {
            get { return ((string)(base["FullName"])); }
            set { base["FullName"] = value; Save(); }
        }

        public string Address
        {
            get { return ((string)(base["Address"])); }
            set { base["Address"] = value; Save(); }
        }
        public int Gender
        {
            get { return ((int)(base["Gender"])); }
            set { base["Gender"] = value; Save(); }
        }
        public string Tel
        {
            get { return ((string)(base["Tel"])); }
            set { base["Tel"] = value; Save(); }
        }
        public string AvatarLink
        {
            get { return ((string)(base["AvatarLink"])); }
            set { base["AvatarLink"] = value; Save(); }
        }
        public int AgentID
        {
            get { return ((int)(base["AgentID"])); }
            set { base["AgentID"] = value; Save(); }
        }
        public int AgentBranchID
        {
            get { return ((int)(base["AgentBranchID"])); }
            set { base["AgentBranchID"] = value; Save(); }
        }
    }

    public class LogOnModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

}
