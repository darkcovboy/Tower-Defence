using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyConfig _enemyConfig;
    [SerializeField] private ParticleSystem _fireEffect;
    [SerializeField] private ParticleSystem _iceEffect;

    private int _health;
    private int _reward;
    private int _damage;
    private float _speed = 10f;

    private float _iceSlowedPercentage;
    private int _iceRates;
    private int _burnDamage;
    private int _burnRates;

    private int _index;
    private Player _target;
    private Warrior _warrior;
    private int _currentHealth;
    private bool _dieCheck = false;
    private Coroutine _fireCoroutine;
    private Coroutine _iceCoroutine;
    

    public int Index => _index;
    public bool HaveEnemy => _warrior == null;
    public int Damage => _damage;
    public bool DieCheck => _dieCheck;
    public int Reward => _reward;
    public Player Target => _target;
    public Warrior Warrior => _warrior;
    public int CurrentHealth => _currentHealth;
    public EnemyType EnemyType => _enemyConfig.EnemyType;

    public float Speed => _speed;

    public event UnityAction<Enemy> Dying;
    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        SetBasicStats();
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void TakeDamage(int damage, DamageType type, int burnDamage, int burnRates)
    {
        CalculateResistForAttack(damage, type);

        _burnDamage = burnDamage;
        _burnRates = burnRates;

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

        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void TakeDamage(int damage, DamageType type, float iceSlowed, int iceRates)
    {
        CalculateResistForAttack(damage, type);

        _iceSlowedPercentage = iceSlowed;
        _iceRates = iceRates;

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

        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void TakeDamage(int damage, DamageType type)
    {
        CalculateResistForAttack(damage, type);
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

    private void SetBasicStats()
    {
        _health = _enemyConfig.Health;
        _reward = _enemyConfig.Reward;
        _speed = _enemyConfig.Speed;
        _damage = _enemyConfig.Damage;
    }

    private IEnumerator OnBurned()
    {
        _fireEffect.gameObject.Activate();

        for (int i = 0; i < _burnRates; i++)
        {
            TakeDamage(_burnDamage, DamageType.Fire);

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
        _speed *= _iceSlowedPercentage;

        for (int i = 0; i < _iceRates; i++)
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
