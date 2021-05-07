using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterWaypointAndMoveController : MonoBehaviour
{
 
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistance;
    [SerializeField] private GameObject _player;
    private float _distance;

    private Vector3 _spawnPositionWaypoint;
    [SerializeField] private float minZOffset = -10f; //����������� �������� �� ��� Z �� ����� ������
    [SerializeField] private float maxZOffset = 10f; //������������ �������� �� ��� Z �� ����� ������

    [SerializeField] private float minXOffset = -10f; //����������� �������� �� ��� X �� ����� ������
    [SerializeField] private float maxXOffset = 10f; //������������ �������� �� ��� X �� ����� ������

    [SerializeField] public int numOfWaypoints = 3;
    [SerializeField] private GameObject _waypointPrefab; //����� ����
    [SerializeField] private GameObject[] _spawnedWayPoints;

    private NavMeshAgent navMeshAgent;
    int m_CurrentWaypointIndex;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");   //����������� ����, ��� ��� ������� ��������� �� ����� ��� ������, � �� �������������� ������� �� ���������� �������� ������ �� �����.        


        if (numOfWaypoints > 0)
            _spawnedWayPoints = SpawnWaypoint();

        if (gameObject.GetComponent<NavMeshAgent>().enabled)
            navMeshAgent.SetDestination(_spawnedWayPoints[0].transform.position);



    }

    void Update()
    {
        if ((numOfWaypoints > 0) && (gameObject.GetComponent<NavMeshAgent>().enabled))
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % _spawnedWayPoints.Length;
                navMeshAgent.SetDestination(_spawnedWayPoints[m_CurrentWaypointIndex].transform.position);
            }
        }

        _distance = (gameObject.transform.position - _player.transform.position).magnitude; //�������� �� �������� =( �� �������� player.transform.position *upd ������ ��������

        if (_distance <= _minDistance) {
            Vector3 relativePos = _player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = rotation;
        }
    }

    GameObject[] SpawnWaypoint()
    {
        GameObject[] point = new GameObject[numOfWaypoints];
        //������� ���� ��� ��������
        for (int i = 0; i < numOfWaypoints; i++)
        {
            float z_pos_way = Random.Range(minZOffset, maxZOffset);
            float x_pos_way = Random.Range(minXOffset, maxXOffset);

            _spawnPositionWaypoint.x = gameObject.transform.position.x + x_pos_way;
            _spawnPositionWaypoint.z = gameObject.transform.position.z + z_pos_way;
            _spawnPositionWaypoint.y = gameObject.transform.position.y;

            point[i] = Instantiate(_waypointPrefab, _spawnPositionWaypoint, Quaternion.identity);
        }
        return point;
    }
}
