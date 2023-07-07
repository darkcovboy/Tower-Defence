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

    [Header("Effects")]
    [SerializeField] private IceEffectData _iceData;
    [SerializeField] private FireEffectData _fireData;

    private Player _target;
    private Warrior _warrior;
    private int _currentHealth;
    private bool _dieCheck = false;
    private Coroutine _fireCoroutine;
    private Coroutine _iceCoroutine;
    private int _index;
    private ParticleSystem _fireEffect;
    private ParticleSystem _iceEffect;

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
        CreateEffects();
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

    private void CreateEffects()
    {
        _fireEffect = Instantiate(_fireData.FireEffect, gameObject.transform.position, Quaternion.identity,gameObject.transform).GetComponent<ParticleSystem>();
        _fireEffect.Deactivate();
        _iceEffect = Instantiate(_iceData.IceEffect, gameObject.transform.position, Quaternion.identity, gameObject.transform).GetComponent<ParticleSystem>();
        _iceEffect.Deactivate();
    }

    private IEnumerator OnBurned()
    {
        _fireEffect.gameObject.Activate();

        for (int i = 0; i < _fireData.BurnRates; i++)
        {
            _currentHealth -= _fireData.BurnDamage;
            HealthChanged?.Invoke(_currentHealth, _health);

            if (_currentHealth <= 0)
            {
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }

        _fireEffect.gameObject.Deactivate();
    }

    private IEnumerator OnIceSlowed()
    {
        _iceEffect.gameObject.Activate();
        float startSpeed = _speed;
        _speed *= _iceData.IceSlowDownPercentage;

        for (int i = 0; i < _iceData.IceRates; i++)
        {
            if (_currentHealth <= 0)
            {
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }

        _speed = startSpeed;
        _iceEffect.gameObject.Deactivate();
    }
}
