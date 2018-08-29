using Realms;

namespace Denna.Office.Common.Domain
{
    class Count : RealmObject
    {
        public RealmInteger<int> Counter { get; set; }
    }
}
