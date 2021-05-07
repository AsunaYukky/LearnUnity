using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnableNavMeshAgent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          gameObject.GetComponent<NavMeshAgent>().enabled = true;
    }
}
