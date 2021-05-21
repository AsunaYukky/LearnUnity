using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Fire1 : MonoBehaviour
{
    [SerializeField] private Camera _camera; // камера
    [SerializeField] private GameObject _mine; // Наша мина
    [SerializeField] private Transform _mineSpawnPlace; // точка, где создается минa
    private Rigidbody _m_Rigitbody;
    [SerializeField] private float _m_Thurst = 200f;
   
    private Animator _anim;
    [SerializeField] private string _fireTriger;
    private int _fireTrigerId;

    private void Awake()
    {
       _anim = GetComponent<Animator>();
       _fireTrigerId = Animator.StringToHash(_fireTriger);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
           
            // Если нажата кнопка  
            if (Input.GetButtonDown("Fire1"))
            {

                var spawned = Instantiate(_mine, _mineSpawnPlace.position, gameObject.transform.rotation); // Создаем _mine в точке _mineSpawnPlace
                _m_Rigitbody = spawned.GetComponent<Rigidbody>();
                _m_Rigitbody.AddForce(0, 0, _m_Thurst, ForceMode.Impulse);
                _anim.SetTrigger(_fireTriger);
            }
    }
}
