using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using IAuthenticationFilter = System.Web.Http.Filters.IAuthenticationFilter;

namespace EFFirst.Filters
{
    public class MyAuthFilter:FilterAttribute, IAuthenticationFilter
    {
        public Task AuthenticateAsync(System.Web.Http.Filters.HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ChallengeAsync(System.Web.Http.Filters.HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnAuthentication(AuthenticationContext filter)
        {

            if (filter.HttpContext.User.Identity.IsAuthenticated == false)
            {
                filter.Result = new HttpUnauthorizedResult();
            }
        }


    }
}