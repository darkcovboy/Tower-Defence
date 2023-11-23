using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainScenePanel : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _instructionButton;
    [SerializeField] private GameObject _instructionPanel;
    [SerializeField] private LevelSelect _levelSelectPanel;


    private void OnEnable()
    {
        _playButton.onClick.AddListener(OpenLevelSelectPanel);
        _instructionButton.onClick.AddListener(OpenInstructionPanel);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OpenLevelSelectPanel);
        _instructionButton.onClick.RemoveListener(OpenInstructionPanel);
    }

    private void OpenInstructionPanel() => _instructionPanel.Activate();
    private void OpenLevelSelectPanel() => _levelSelectPanel.gameObject.Activate();
}
