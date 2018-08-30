using System.Threading.Tasks;
using Realms.Sync;
using System.Linq;
using System;
using Realms;
using Denna.Office.Common.Domain;
using Denna.Office.Common.Data;

namespace Denna.Office.Common.Services.Users
{
    public class UserService
    {

        public async Task Login(string username, string password)
        {
            var credentials = Credentials.UsernamePassword(username.ToLower(), password, createUser: false);
            //var user = await User.LoginAsync(credentials, Constants.ServerUri);
            User.ConfigurePersistence(UserPersistenceMode.Encrypted);

        }

        public async void Logout()
        {
            await User.Current.LogOutAsync();
        }

        public bool IsUserLoggenIn() => User.AllLoggedIn.Any();

        public string GetUsername()
        {
            var usr = GetUserInfo();
            if (string.IsNullOrEmpty(usr.Username))
                return User.Current.Identity;

            else return usr.Username;
        }


        public DennaUser GetUserInfo()
        {
            var instance = RealmContext.GetInstance();
            return instance.All<DennaUser>().FirstOrDefault();
        }
    }
}
