using UnityEngine;
using Zenject;

public class RewardedHealthVideo : RewardedVideo
{
    private const float RadiusExplosion = 15f;

    private IHealible _healible;
    private int _adHealth;
    private Transform _position;

    [Inject]
    public void Init(IHealible healible)
    {
        _healible = healible;
    }

    public RewardedHealthVideo(Transform explosionPosition, int health)
    {
        _position = explosionPosition;
        _adHealth = health;
    }

    protected override void OnRewardedCallback()
    {
        AddHealth();
        KillEnemies();
    }

    private void AddHealth() => _healible.AddHealth(_adHealth);

    private void KillEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_position.position, RadiusExplosion, 1, QueryTriggerInteraction.Collide);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                switch (enemy.EnemyType)
                {
                    case (EnemyType.Common):
                        {
                            enemy.TakeDamage(enemy.CurrentHealth);
                            break;
                        }
                    case (EnemyType.Boss):
                        {
                            enemy.RollBack();
                            break;
                        }
                }
            }
        }
    }

}
