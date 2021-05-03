using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    public void Hurt(int damage)
    {
        Debug.Log("Hit: " +damage);

        _health -= damage; ;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var anim = gameObject.GetComponent<Animation>();
        if (anim != null) {

            anim.Play("Death");

        }
        Destroy(gameObject);
    }
}
