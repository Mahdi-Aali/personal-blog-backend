using Microsoft.AspNetCore.Identity;

namespace personalblog.sso.domain.Aggregates.RoleAggregates;

public class PersonalBlogRole : IdentityRole<Guid>
{
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
