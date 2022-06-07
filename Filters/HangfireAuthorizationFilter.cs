using Hangfire.Dashboard;
using Hangfire.Annotations;

namespace broker.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            // ToDo: implment authentication
            // return httpContext.User.Identity.IsAuthenticated;
            return true;
        }
    }
}
