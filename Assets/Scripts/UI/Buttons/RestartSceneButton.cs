using UnityEngine.SceneManagement;
using Zenject;

public class RestartSceneButton : AbstractButton
{
    private FullVideo _fullVideo;
    private SoundButton _soundButton;

    [Inject]
    public void Init(FullVideo fullVideo, SoundButton soundButton)
    {
        _fullVideo = fullVideo;
        _soundButton = soundButton;
    }

    protected override void OnButtonClick()
    {
        _soundButton.Play();
        Restart();
    }

    private void Restart()
    {
        _fullVideo.Show(SceneManager.GetActiveScene().name);
    }
}
