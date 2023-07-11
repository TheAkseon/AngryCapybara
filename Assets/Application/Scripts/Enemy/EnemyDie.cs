using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    [SerializeField] private ForceManager _forceManager;

    private List<Enemy> _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>().ToList();

        foreach (Enemy enemy in _enemies)
        {
            enemy.Die += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Die -= OnEnemyDied;
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        PlayerModifier playerModifier = FindObjectOfType<PlayerModifier>();
        if (playerModifier)
        {
            if(enemy.NumberOfForce < _forceManager.NumberOfForce)
            {
                playerModifier.AddWidth(enemy.NumberOfForce);
                playerModifier.AddHeight(enemy.NumberOfForce);
                _forceManager.AddForce(enemy.NumberOfForce);
                PlayerAnimationController.Instance.Hit();
                SoundsManager.Instance.PlaySound("EnemyHit");
                SoundsManager.Instance.PlaySound("Teleport");
            }
            else if(enemy.NumberOfForce >= _forceManager.NumberOfForce && !PlayerMove.Instance.IsInvulnerble)
            {
                PlayerModifier.Instance.Die();
            }
        }
        enemy.Die -= OnEnemyDied;
        _enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
