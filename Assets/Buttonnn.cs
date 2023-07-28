using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonnn : AbstractButton
{
    [SerializeField] private Spawner _spawner;

    private List<Enemy> _enemy = new List<Enemy>();

    private void Update()
    {
        _enemy.Add(FindObjectOfType<Enemy>());
    }

    protected override void OnButtonClick()
    {
        for (int i = 0; i < _spawner.EnemyLiev.Count; i++)
        {
            Enemy enemy = _spawner.EnemyLiev[i].GetComponent<Enemy>();
            enemy.RollBack();
        }
    }
}
