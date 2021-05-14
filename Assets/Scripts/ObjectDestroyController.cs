using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyController : MonoBehaviour
{

    [SerializeField] private float DestroyTimer = 30f;

    private void Start()
    {
        Destroy(gameObject, DestroyTimer);
    }

    // Update is called once per frame
    void Update()
    {



    }
}
