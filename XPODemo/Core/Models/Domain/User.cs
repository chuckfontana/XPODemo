using DevExpress.Xpo;

namespace XPODemo.Core.Models.Domain
{
    public class User:BaseObject
    {
        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                SetPropertyValue("LastName", ref _LastName, value);
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                SetPropertyValue("FirstName", ref _FirstName, value);
            }
        }

        public User(Session session) : base(session) { }
    }
}
