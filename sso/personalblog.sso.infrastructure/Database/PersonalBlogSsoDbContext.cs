using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using personalblog.sso.domain.Aggregates.RoleAggregates;
using personalblog.sso.domain.Aggregates.UserAggregates;

namespace personalblog.sso.infrastructure.Database;

public class PersonalBlogSsoDbContext : IdentityDbContext<PersonalBlogUser, PersonalBlogRole, Guid>
{

}
