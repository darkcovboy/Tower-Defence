using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    [SerializeField] private Image _fillArea;
    [SerializeField] private SpellType _spellType;

    public SpellType Type => _spellType;

    private int _secondsToFill;
    private Animator _animator;
    private Button _button;

    private readonly string _selectAnimation = "Selected";

    private void Start()
    {
        _button = GetComponent<Button>();
        _animator = GetComponent<Animator>();
    }

    public void OffButton(int seconds)
    {
        _button.interactable = false;
        _secondsToFill = seconds;
        StartCoroutine(FillArea());
    }

    public void OnButton()
    {
        _button.interactable = true;
    }

    public void Select()
    {
        _animator.SetBool(_selectAnimation, true);
    }

    public void DeSelect()
    {
        _animator.SetBool(_selectAnimation, false);
    }

    private IEnumerator FillArea()
    {
        _fillArea.fillAmount = 1f;

        for (float time = _secondsToFill; time > 0f; time -= Time.deltaTime)
        {
            _fillArea.fillAmount = time / _secondsToFill;
            yield return null;
        }

        _fillArea.fillAmount = 0f;
    }
}
