using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float mouseAccelerationX = 1.5f; // Ускорение мыши по оси X
    [SerializeField] private Vector3 _mouse; //Направление "Взгляда" по мышке
    [SerializeField] private float minDegree;
    [SerializeField] private float maxDegree;
    [SerializeField] private bool mouseInversionX = false;
    [SerializeField] private GameObject _camera;

    private float IsInversed() {
        if (mouseInversionX) 
            return 100f;
        else 
            return -100f;
    }

    void Start() 
    {
        Cursor.visible = false; // отключаем курсор чтоб не мешал *UPD всеменно выключил
    }

    void Update()
    {
        _mouse.x = Input.GetAxis("Mouse Y");
        
    }

    void FixedUpdate()
    {
        var mouse = _mouse * mouseAccelerationX * IsInversed() * Time.deltaTime;
        _camera.transform.Rotate(mouse);
    }


}
