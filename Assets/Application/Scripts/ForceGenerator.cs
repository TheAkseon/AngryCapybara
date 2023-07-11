using System.Collections.Generic;
using UnityEngine;

public class ForceGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 _forceMultiplie = new(1.3f, 1.6f);

    private readonly List<GameObject> _enemies = new();

    private float _force = 4;

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _enemies.Add(gameObject.transform.GetChild(i).gameObject);
        }

        GenerateForces();
    }

    public void GenerateForces()
    {
        foreach(GameObject enemy in _enemies)
        {
            enemy.GetComponent<Enemy>().SetForce(Mathf.CeilToInt(_force));
            _force = Random.Range(_force * _forceMultiplie.x, _force * _forceMultiplie.y);
        }
    }
}
