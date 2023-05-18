using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;

    public event UnityAction<BaseEnemy> Died;

    private void Update()
    {
        Move();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
            Died?.Invoke(this);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Move()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
