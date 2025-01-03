using Microsoft.AspNetCore.Identity;

namespace personalblog.sso.domain.Aggregates.UserAggregates;

public class PersonalBlogUser : IdentityUser<Guid>
{
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
