using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyConfig _enemyConfig;

    private int _health;
    private int _reward;
    private int _damage;
    private float _speed = 10f;

    private IceEffectData _iceData;
    private FireEffectData _fireData;
    private LightningData _lightningData;

    private int _index;
    private Player _target;
    private Warrior _warrior;
    private int _currentHealth;
    private bool _dieCheck = false;
    private Coroutine _fireCoroutine;
    private Coroutine _iceCoroutine;
    private Coroutine _lightningCoroutine;
    private ParticleSystem _fireEffect;
    private ParticleSystem _iceEffect;
    private ParticleSystem _lightningEffect;
    private bool _isLightningConfused = false;

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
        SetBasicStats();
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
        CalculateResistForAttack(damage, type);

        switch (type)
        {
            case DamageType.Fire:
                {
                    if (_fireCoroutine == null)
                    {
                        _fireCoroutine = StartCoroutine(OnBurned());
                    }
                    else
                    {
                        if (_iceCoroutine != null)
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
            case DamageType.Lightning:
                {
                    if (_lightningCoroutine == null)
                    {
                        _lightningCoroutine = StartCoroutine(OnLightningConfused());
                    }
                    break;
                }
            case DamageType.Physical:
                {
                    break;
                }
            default:
                {
                    break;
                }
        }

        HealthChanged?.Invoke(_currentHealth, _health);
    }
    #region
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
    #endregion

    private void CalculateResistForAttack(int damage, DamageType damageType)
    {
        if (_isLightningConfused)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    _currentHealth -= (int)(damage * _enemyConfig.PhysicalResistace * _lightningData.LightningDamageMultiplier);
                    break;
                case DamageType.Fire:
                    _currentHealth -= (int)(damage * _enemyConfig.FireResistace * _lightningData.LightningDamageMultiplier);
                    break;
                case DamageType.Ice:
                    _currentHealth -= (int)(damage * _enemyConfig.IceResisnace * _lightningData.LightningDamageMultiplier);
                    break;
                case DamageType.Lightning:
                    _currentHealth -= (int)(damage * _enemyConfig.LightningResistace * _lightningData.LightningDamageMultiplier);
                    break;
            }

            _isLightningConfused = false;

            if (_lightningCoroutine != null)
            {
                StopCoroutine(_lightningCoroutine);
                _lightningCoroutine = null;
            }
        }
        else
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    _currentHealth -= (int)(damage * _enemyConfig.PhysicalResistace);
                    break;
                case DamageType.Fire:
                    _currentHealth -= (int)(damage * _enemyConfig.FireResistace);
                    break;
                case DamageType.Ice:
                    _currentHealth -= (int)(damage * _enemyConfig.IceResisnace);
                    break;
                case DamageType.Lightning:
                    _currentHealth -= (int)(damage * _enemyConfig.LightningResistace);
                    break;
            }
        }
    }

    private void SetBasicStats()
    {
        _health = _enemyConfig.Health;
        _reward = _enemyConfig.Reward;
        _speed = _enemyConfig.Speed;
        _damage = _enemyConfig.Damage;
        _iceData = _enemyConfig.IceEffectData;
        _fireData = _enemyConfig.FireEffectData;
        _lightningData = _enemyConfig.LightningData;
    }

    private void CreateEffects()
    {
        _fireEffect = Instantiate(_fireData.FireEffect, gameObject.transform.position, Quaternion.identity, gameObject.transform).GetComponent<ParticleSystem>();
        _fireEffect.Deactivate();
        _iceEffect = Instantiate(_iceData.IceEffect, gameObject.transform.position, Quaternion.identity, gameObject.transform).GetComponent<ParticleSystem>();
        _iceEffect.Deactivate();
        _lightningEffect = Instantiate(_lightningData.LightningEffect, gameObject.transform.position, Quaternion.identity, gameObject.transform).GetComponent<ParticleSystem>();
        _lightningEffect.Deactivate();
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

    private IEnumerator OnLightningConfused()
    {
        _lightningEffect.gameObject.Activate();
        _isLightningConfused = true;

        for (int i = 0; i < _lightningData.LightningRate; i++)
        {
            if (_currentHealth <= 0)
            {
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }

        _isLightningConfused = false;
        _lightningEffect.gameObject.Deactivate();
    }
}
