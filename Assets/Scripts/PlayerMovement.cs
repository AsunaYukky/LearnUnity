using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _speed = 5f; //скорость движения и ускорение
    [SerializeField] private Vector3 _direction; //Направление движения
    [SerializeField] private float _mouseAccelerationY = 1.5f; // Ускорение мыши по оси Y
    [SerializeField] private Vector3 _mouse; //Направление движения по мышке
    [SerializeField] private GameObject _player;

    private Animator _anim;
    [SerializeField] private string _walkTriger;
    private int _walkTrigerId;

    private void Awake()
    {
        _anim = gameObject.GetComponent<Animator>();
        _walkTrigerId = Animator.StringToHash(_walkTriger);
    }

    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction.y = Input.GetAxis("Jump");
        _mouse.y = Input.GetAxis("Mouse X");
    }

    void FixedUpdate()
    {
        
        var speed = _direction * _speed * Time.deltaTime;
        _player.transform.Translate(speed);
        if (speed.x != 0f || speed.y != 0 || speed.z != 0f) {
            _anim.SetFloat(_walkTrigerId, _speed);
        }


        var mouse = _mouse * _mouseAccelerationY * 100 * Time.deltaTime;
        _player.transform.Rotate(mouse);
    }
}
