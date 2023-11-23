using UnityEngine;

[CreateAssetMenu(menuName ="Level/PrefabContainer")]
public class LevelPrefabsContainer : ScriptableObject
{
    public SoundButton SoundButton;
    public SceneFader FaderPrefab;
    public SpawnPlaceTower SpawnPlaceTowerPrefab;
}
