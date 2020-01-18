using DevExpress.Xpo;
using System;
using XPODemo.Core.Helper;

namespace XPODemo.Core.Models.Domain
{
    [NonPersistent]
    public abstract class BaseObject:XPObject
    {
        private DateTime _CreateDateTime;
        public DateTime CreateDateTime
        {
            get
            {
                return _CreateDateTime;
            }
            set
            {
                SetPropertyValue("CreateDateTime", ref _CreateDateTime, value);
            }
        }

        private User _CreateUser;
        public User CreateUser
        {
            get
            {
                return _CreateUser;
            }
            set
            {
                SetPropertyValue("CreateUser", ref _CreateUser, value);
            }
        }

        private DateTime _UpdateDateTime;
        public DateTime UpdateDateTime
        {
            get
            {
                return _UpdateDateTime;
            }
            set
            {
                SetPropertyValue("UpdateDateTime", ref _UpdateDateTime, value);
            }
        }

        private User _UpdateUser;
        public User UpdateUser
        {
            get
            {
                return _UpdateUser;
            }
            set
            {
                SetPropertyValue("UpdateUser", ref _UpdateUser, value);
            }
        }

        protected BaseObject(Session session) : base(session) { }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (this.Session.IsNewObject(this))
            {
                this.CreateDateTime = DateTime.Now;
                this.CreateUser = this.Session.FindObject<User>(AppHelper.CurrentUserOid);
            }

            this.UpdateDateTime = DateTime.Now;
            this.UpdateUser = this.Session.FindObject<User>(AppHelper.CurrentUserOid);
        }

    }
}
