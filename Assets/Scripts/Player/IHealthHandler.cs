using System;

public interface IHealthHandler
{
    event Action<int> OnHealthChanged;
}
