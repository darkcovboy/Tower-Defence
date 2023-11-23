using Zenject;

public class MainMenuButton : AbstractButton
{
    private const string MainMenuName = "MainMenu";

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
        GoMainMenu();
    }

    private void GoMainMenu()
    {
        _fullVideo.Show(MainMenuName);
    }
}
