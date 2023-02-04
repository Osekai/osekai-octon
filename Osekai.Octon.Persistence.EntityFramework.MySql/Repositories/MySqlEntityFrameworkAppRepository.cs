﻿using Microsoft.EntityFrameworkCore;
using Osekai.Octon.Objects;
using Osekai.Octon.Persistence.EntityFramework.MySql.Dtos;
using Osekai.Octon.Persistence.EntityFramework.MySql.Models;
using Osekai.Octon.Persistence.Repositories;

namespace Osekai.Octon.Persistence.EntityFramework.MySql.Repositories;

public class MySqlEntityFrameworkAppRepository: IAppRepository
{
    protected MySqlOsekaiDbContext Context { get; }
    internal MySqlEntityFrameworkAppRepository(MySqlOsekaiDbContext context)
    {
        Context = context;
    }

    public async Task<IReadOnlyApp?> GetAppByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        App? app = await Context.Apps.FindAsync(new object[] {id}, cancellationToken);
        
        return app?.ToDto();
    }

    public async Task<bool> PatchAppAsync(int id, int order, string name, string simpleName, bool visible,
        bool experimental, CancellationToken cancellationToken = default)
    {
        App? app = await Context.Apps.FindAsync(new object?[] { id }, cancellationToken);
        if (app == null)
            return false;
        
        app.Name = name;
        app.SimpleName = simpleName;
        app.Order = order;
        app.Visible = visible;
        app.Experimental = experimental;
        
        return true;
    }

    public async Task<IEnumerable<IReadOnlyApp>> GetAppsAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<App> app = await Context.Apps.ToArrayAsync(cancellationToken);
        return app.Select(app => app.ToDto());
    }
}