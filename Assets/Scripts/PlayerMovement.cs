using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _speed = 5f; //�������� �������� � ���������
    [SerializeField] private Vector3 _direction; //����������� ��������
    [SerializeField] private float mouseAccelerationY = 1.5f; // ��������� ���� �� ��� Y
    [SerializeField] private Vector3 _mouse; //����������� �������� �� �����
    [SerializeField] private GameObject _player;

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

        var mouse = _mouse * mouseAccelerationY * 100 * Time.deltaTime;
        _player.transform.Rotate(mouse);
    }
}
