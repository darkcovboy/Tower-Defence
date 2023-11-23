using Zenject;
using UnityEngine;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private MainPrefabContainer _containerPrefabs;

    public override void InstallBindings()
    {
        CreateSave();
        CreateLoading();
    }

    private void CreateSave()
    {
        SaveManagerContainer saveManagerContainer = FindObjectOfType<SaveManagerContainer>();


        if(saveManagerContainer == null)
        {
            saveManagerContainer = Container.InstantiatePrefabForComponent<SaveManagerContainer>(_containerPrefabs.SaveManager);
            saveManagerContainer.Create();
            Container.Bind<SaveManager>().FromInstance(SaveManagerContainer.PlayerSave);
        }
        else
        {
            Container.Bind<SaveManager>().FromInstance(SaveManagerContainer.PlayerSave);
        }
    }

    private void CreateLoading()
    {
        if(LoadingPanel.Instance == null)
        {
            LoadingPanel loadingPanel = Container.InstantiatePrefabForComponent<LoadingPanel>(_containerPrefabs.LoadingCurtain);
            Container.Bind<LoadingPanel>().FromInstance(loadingPanel).AsSingle();
        }
        else
        {
            Container.Bind<LoadingPanel>().FromInstance(LoadingPanel.Instance).AsSingle();
        }
    }
}
