﻿using Microsoft.EntityFrameworkCore;
using Osekai.Octon.Objects;
using Osekai.Octon.Persistence.EntityFramework.MySql.Dtos;
using Osekai.Octon.Persistence.EntityFramework.MySql.Models;
using Osekai.Octon.Persistence.Repositories;

namespace Osekai.Octon.Persistence.EntityFramework.MySql.Repositories;

public class MySqlEntityFrameworkAppThemeRepository: IAppThemeRepository
{
    protected MySqlOsekaiDbContext Context { get; }
    
    public MySqlEntityFrameworkAppThemeRepository(MySqlOsekaiDbContext context)
    {
        Context = context;
    }
    
    public async Task<IReadOnlyAppTheme?> GetAppThemeByAppIdAsync(int appId, CancellationToken cancellationToken = default)
    {
        AppTheme? theme = await Context.AppThemes.Where(e => e.AppId == appId).FirstOrDefaultAsync(cancellationToken);
        return theme?.ToDto();
    }
}