using UnityEngine;

[CreateAssetMenu(menuName = "Level/MainScenePrefab")]
public class MainPrefabContainer : ScriptableObject
{
    public LoadingPanel LoadingCurtain;
    public SaveManagerContainer SaveManager;
}
