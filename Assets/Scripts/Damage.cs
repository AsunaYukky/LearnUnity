using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Damage : MonoBehaviour
{
    [SerializeField] private int _damage = 50;
    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyHealthController>();
        if (enemy == null)
            return;

        if (!enemy.enabled)
            return;
        
        enemy.Hurt(_damage);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        _audioSource.Play();
        _particleSystem.Play();
        Destroy(gameObject, 8f);
    }

}
