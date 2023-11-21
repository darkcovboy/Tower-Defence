using UnityEngine;

[CreateAssetMenu(menuName ="Level/PrefabContainer")]
public class LevelPrefabsContainer : ScriptableObject
{
    public SceneFader FaderPrefab;
    public Spawner SpawnerPrefab;
    public SpawnPlaceTower SpawnPlaceTowerPrefab;
    public Player Player;
}
