﻿using Osekai.Octon.Persistence.EntityFramework.MySql.Dtos;

namespace Osekai.Octon.Persistence.EntityFramework.MySql.Entities;

internal sealed class MedalSettings
{
    public int Id { get; set; }
    public int MedalId { get; set; }
    public Medal Medal { get; set; } = null!;
    public bool Locked { get; set; }

    public MedalSettingsDto ToDto()
    {
        return new MedalSettingsDto(Locked);
    }
}