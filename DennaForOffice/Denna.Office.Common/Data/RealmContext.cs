using Realms;
using Realms.Sync;
using System;

namespace Denna.Office.Common.Data
{
    public static class RealmContext
    {
        public static Realm GetInstance()
        {
            //var configuration = new SyncConfiguration(User.Current, new Uri("~/myRealm", UriKind.Relative)) { SchemaVersion = 1 };
            return Realm.GetInstance("DennaLocal.realm");
        }
    }
}
