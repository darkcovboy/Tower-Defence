using UnityEngine;

public class EnemyFactory : ScriptableObject
{
    public Enemy Get(Enemy prefab, Transform parent, Waypoints waypoints)
    {
        Enemy instance = Instantiate(prefab, parent);
        instance.GetComponent<EnemyMoverState>().Init(waypoints);
        return instance;
    }
}
