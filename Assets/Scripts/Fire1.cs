using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1 : MonoBehaviour
{
    [SerializeField] private GameObject _mine; // Наша мина
    [SerializeField] private Transform _mineSpawnPlace; // точка, где создается мина
    
    private Rigidbody m_Rigitbody;
    [SerializeField] private float m_Thurst = 5000f;
    
    private void Update()
    {
        // Если нажата кнопка  
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation); // Создаем _mine в точке _mineSpawnPlace
           
            
            m_Rigitbody = _mine.GetComponent<Rigidbody>(); 
            
            m_Rigitbody.AddForce(0, 0, m_Thurst, ForceMode.Impulse); 

    }

    }

}
