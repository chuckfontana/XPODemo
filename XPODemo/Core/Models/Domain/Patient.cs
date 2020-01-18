using DevExpress.Xpo;
using System;
using XPODemo.Core.Helper;

namespace XPODemo.Core.Models.Domain
{
    public class Patient : BaseObject
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

        private string _MRN;
        [Indexed(Unique=true)]
        public string MRN
        {
            get
            {
                return _MRN;
            }
            set
            {
                SetPropertyValue("MRN", ref _MRN, value);
            }
        }

        private DateTime? _DateOfBirth;
        public DateTime? DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                SetPropertyValue("DateOfBirth", ref _DateOfBirth, value);
            }
        }



        public Patient(Session session) : base(session) { }
    }
}
