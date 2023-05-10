using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DragonFlame : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private BaseEnemy _target;

    private const string Flame = "Flame";

    private Animator _animator;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(Flame);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void Init(BaseEnemy target)
    {
        _target = target;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BaseEnemy enemy))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }        
}
