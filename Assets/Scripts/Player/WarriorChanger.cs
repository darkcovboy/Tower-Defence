using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorChanger : MonoBehaviour
{
    [SerializeField] private List<Warrior> _warriors;

    public Warrior Warrior => _warriors[_level];

    public bool IsWarriorActive => _warriors[_level].gameObject.activeSelf;

    private int _level = 0;

    private void Start()
    {
        foreach (var warrior in _warriors)
        {
            warrior.gameObject.Deactivate();
        }

        _warriors[_level].gameObject.Activate();
    }

    public void Upgrade(BarracksTower barracksTower)
    {
        Transform target = _warriors[_level].Target;
        _level++;

        foreach (var warrior in _warriors)
        {
            warrior.gameObject.Deactivate();
        }

        _warriors[_level].gameObject.Activate();
        _warriors[_level].SendData(target, barracksTower);
    }
}
