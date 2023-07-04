﻿using Microsoft.AspNetCore.Identity;

namespace Shop.Domain.Entities.Identity;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public virtual ApplicationUser User { get; set; }
    public virtual ApplicationRole Role { get; set; }
}