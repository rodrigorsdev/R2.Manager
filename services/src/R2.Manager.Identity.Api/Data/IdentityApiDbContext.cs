using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace R2.Manager.Identity.Api.Data
{
    public class IdentityApiDbContext : IdentityDbContext
    {
        public IdentityApiDbContext(DbContextOptions<IdentityApiDbContext> options) : base(options)
        { }
    }
}
