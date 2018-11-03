namespace SIS.Framework.Attributes.Action
{
    using System;
    using System.Linq;

    using SIS.Framework.Security;

    public class AuthorizeAttribute : Attribute
    {
        private readonly string role;

        public AuthorizeAttribute()
        {

        }

        public AuthorizeAttribute(string role)
        {
            this.role = role;
        }

        private bool IsIdentityPresent(IIdentity identity)
        {
            if (identity != null)
            {
                return true;
            }

            return false;
        }

        private bool IsIdentityInRole(IIdentity identity)
        {
            if (this.IsIdentityPresent(identity))
            {
                if (identity.Roles.Contains(this.role))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public bool IsAuthorized(IIdentity user)
        {
            if (this.role == null)
            {
                return this.IsIdentityPresent(user);
            }

            return this.IsIdentityInRole(user);
        }
    }
}