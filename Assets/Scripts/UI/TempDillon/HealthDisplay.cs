using UnityEngine;
using TMPro;
using Zenject;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;

    private IHealthHandler _healthHandler;

    [Inject]
    public void Constructor(IHealthHandler healthHandler)
    {
        _healthHandler = healthHandler;
    }

    private void OnEnable()
    {
        _healthHandler.OnHealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _healthHandler.OnHealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthText.text = health.ToString();
    }
}
