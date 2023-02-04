﻿namespace Osekai.Octon.Objects;

public interface IReadOnlyApp
{
    int Id { get; }
    int Order { get; }
    string Name { get; } 
    string SimpleName { get; }
    bool Visible { get; }
    bool Experimental { get; }
}