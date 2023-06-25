using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed = 10f;

    [Header("Damage Fire Settings")]
    [SerializeField] private int _burnRates;
    [SerializeField] private int _burnDamage;
    [SerializeField] private ParticleSystem _fireEffect;
    [Header("Damage Ice Settings")]
    [SerializeField] private int _iceRates;
    [Range(0,1)]
    [SerializeField] private float _iceSpeedPercentage;
    [SerializeField] private ParticleSystem _iceEffect;

    private Player _target;
    private Warrior _warrior;
    private int _currentHealth;
    private bool _dieCheck = false;
    private Coroutine _fireCoroutine;
    private Coroutine _iceCoroutine;
    private int _index;

    public int Index => _index;
    public bool HaveEnemy => _warrior == null;
    public int Damage => _damage;
    public bool DieCheck => _dieCheck;
    public int Reward => _reward;
    public Player Target => _target;
    public Warrior Warrior => _warrior;
    public int CurrentHealth => _currentHealth;

    public float Speed => _speed;

    public event UnityAction<Enemy> Dying;
    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void TakeDamage(int damage, DamageType type)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        switch(type)
        {
            case DamageType.Fire:
                {
                    if(_fireCoroutine == null)
                    {
                        _fireCoroutine = StartCoroutine(OnBurned());
                    }
                    else
                    {
                        if(_iceCoroutine != null)
                        {
                            StopCoroutine(_iceCoroutine);
                            _iceCoroutine = null;
                        }
                    }
                    break;
                }
            case DamageType.Ice:
                {
                    if (_iceCoroutine == null)
                    {
                        _iceCoroutine = StartCoroutine(OnIceSlowed());
                    }
                    else
                    {
                        if (_fireCoroutine != null)
                        {
                            StopCoroutine(_fireCoroutine);
                            _fireCoroutine = null;
                        }
                    }
                    break;
                }
            case DamageType.Physical:
                {
                    break;
                }
        }
    }

    public void Init(Player target, Warrior warrior)
    {
        _target = target;
        _warrior = warrior;
    }

    public void Init(Warrior warrior)
    {
        _warrior = warrior;
    }

    public void DyingEnemy()
    {
        Dying.Invoke(this);
    }

    public void OnDie()
    {
        _dieCheck = true;
    }

    public void TargetNull()
    {
        _warrior = null;
    }

    public void GetIndexToArray(int index)
    {
        _index = index;
    }

    private IEnumerator OnBurned()
    {
        _fireEffect.gameObject.SetActive(true);

        for (int i = 0; i < _burnRates; i++)
        {
            _currentHealth -= _burnDamage;
            HealthChanged?.Invoke(_currentHealth, _health);

            if (_currentHealth <= 0)
            {
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }

        _fireEffect.gameObject.SetActive(false);
    }

    private IEnumerator OnIceSlowed()
    {
        _iceEffect.gameObject.SetActive(true);
        float startSpeed = _speed;
        _speed *= _iceSpeedPercentage;

        for (int i = 0; i < _iceRates; i++)
        {
            if (_currentHealth <= 0)
            {
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }

        _speed = startSpeed;
        _iceEffect.gameObject.SetActive(false);
    }
}
