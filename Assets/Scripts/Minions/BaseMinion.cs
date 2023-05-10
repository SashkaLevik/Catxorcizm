using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMinion : MonoBehaviour
{
    [SerializeField] private Transform _firePos;
    [SerializeField] private DragonFlame _flame;
    [SerializeField] private BaseEnemy _target;
    [SerializeField] private int _speed;
    [SerializeField] private int _fireDelay;

    public BaseEnemy Target => _target;

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BaseEnemy enemy))
        {
            if (_target != null)
            {
                Attack();
            }
        }
    }

    public void Init(BaseEnemy target)
    {
        _target = target;
    }

    private void Attack()
    {
        //DragonFlame flame = Instantiate(_flame, _firePos.position, Quaternion.identity);
        //flame.Init(Target);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (_target != null)
        {
            var delay = new WaitForSeconds(2f);
            DragonFlame flame = Instantiate(_flame, _firePos.position, Quaternion.identity);
            flame.Init(Target);
            yield return delay;
        }        
    }

    private void Move()
    {
        //transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
