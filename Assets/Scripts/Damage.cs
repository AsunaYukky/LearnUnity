using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damage = 50;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyHealthController>();
        if (enemy == null)
            return;

        if (!enemy.enabled)
            return;
        
        enemy.Hurt(_damage);
        Destroy(gameObject);
    }

}
