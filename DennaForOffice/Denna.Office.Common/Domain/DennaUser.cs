using Realms;

namespace Denna.Office.Common.Domain
{
    public class DennaUser : RealmObject
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
