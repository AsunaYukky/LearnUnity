using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float mouseAccelerationX = 1.5f; // Ускорение мыши по оси X
    [SerializeField] private Vector3 _mouse; //Направление "Взгляда" по мышке
    [SerializeField] private bool mouseInversionX = false;


    
    

    private float isInversed() {

        if (mouseInversionX) return 100f;
        else return -100f;

    }

    private void Start() 
    {
        Cursor.visible = false; // отключаем курсор чтоб не мешал
    }


    void Update()
    {
        _mouse.x = Input.GetAxis("Mouse Y");

    }


    void FixedUpdate()
    {

        var mouse = _mouse * mouseAccelerationX * isInversed() * Time.deltaTime;

        transform.Rotate(mouse);
     
    }


}
