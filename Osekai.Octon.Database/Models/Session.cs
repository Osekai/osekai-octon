﻿namespace Osekai.Octon.Database.Models;

public sealed class Session
{
    public string Token { get; set; } = null!;
    public string Payload { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
}