using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    private Animator _anim;
    [SerializeField] private string _deathTriger;
    private int _deathTrigerId;
    [SerializeField] private string _hitTriger;
    private int _hitTrigerId;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _deathTrigerId = Animator.StringToHash(_deathTriger);
        _hitTrigerId = Animator.StringToHash(_hitTriger);
    }

    public void Hurt(int damage)
    {
        Debug.Log("Hit: " +damage);

        _health -= damage;
        _anim.SetTrigger(_hitTrigerId);
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _anim.SetTrigger(_deathTrigerId);
        Destroy(gameObject, 1);
    }
}
