using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1 : MonoBehaviour
{
    [SerializeField] private GameObject _mine; // ���� ����
    [SerializeField] private Transform _mineSpawnPlace; // �����, ��� ��������� ����
    
    private Rigidbody m_Rigitbody;
    [SerializeField] private float m_Thurst = 100f;
    
    private void Update()
    {
        // ���� ������ ������  
        if (Input.GetButtonDown("Fire1"))
        {
            var spawned = Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation); // ������� _mine � ����� _mineSpawnPlace

            m_Rigitbody = spawned.GetComponent<Rigidbody>();
            m_Rigitbody.AddForce(0, 0, m_Thurst, ForceMode.Impulse);
        }
    }
}
