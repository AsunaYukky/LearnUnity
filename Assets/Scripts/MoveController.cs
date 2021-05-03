using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private GameObject[] _waypoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistance;
    
    private float _distance;

    [SerializeField] private GameObject _player;

   

    // Update is called once per frame
    void Update()
    {
        _distance = (gameObject.transform.position - _player.transform.position).magnitude; //почемуто не работает =( не меняется player.transform.position
        Debug.Log(_player.transform.position);

        if (_distance <= _minDistance) {

            Vector3 relativePos = transform.position - _player.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = rotation;


        }

        




       // go();

    }

    void go() { //бесконечный мать его цикл

        if (_waypoint != null)
        {


            for (int i = 0; i < _waypoint.Length; i++)
            {

                transform.position = Vector3.MoveTowards(transform.position, _waypoint[i].transform.position, _speed * Time.deltaTime);
                i++;
                if (i == _waypoint.Length)
                {
                    i = 0;
                    go();
                }
            }
        }



    }
}
