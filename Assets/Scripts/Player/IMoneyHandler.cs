using System;

public interface IMoneyHandler
{
    event Action<int> OnMoneyChanged;
}
