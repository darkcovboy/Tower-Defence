using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsCreator : MonoBehaviour
{
    [SerializeField] private MeteorShoot _meteorShootPrefab;
    [SerializeField] private WarriorsCreator _warriorCreatorPrefab;

    public MeteorShoot CreateMeteor(bool canCreate)
    {
        if(canCreate)
        {
            var spell = Instantiate(_meteorShootPrefab);
            return spell;
        }
        else
        {
            return null;
        }
    }

    public WarriorsCreator CreateWarrior(bool canCreate)
    {
        if (canCreate)
        {
            var spell = Instantiate(_warriorCreatorPrefab);
            return spell;
        }
        else
        {
            return null;
        }
    }
}
