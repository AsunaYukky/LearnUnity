using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ObjectDestroyController : MonoBehaviour
{

    [SerializeField] private float _destroyTimer;

    private void Start()
    {

        Destroy(gameObject, _destroyTimer);
    }

}
