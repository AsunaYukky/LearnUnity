using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damage = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealthController>().enabled)
        {
            var enemy = other.GetComponent<EnemyHealthController>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
        }
    }

}
