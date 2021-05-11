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
    [SerializeField] private float WaypointMinZOffset = -10f; //минимальное смещение по оси Z от точки спавна
    [SerializeField] private float WaypointMaxZOffset = 10f; //максимальное смещение по оси Z от точки спавна

    [SerializeField] private float WaypointMinXOffset = -10f; //минимальное смещение по оси X от точки спавна
    [SerializeField] private float WaypointMaxXOffset = 10f; //максимальное смещение по оси X от точки спавна

    [SerializeField] public int numOfWaypoints = 3;
    [SerializeField] private GameObject _waypointPrefab; //Точки пути
    [SerializeField] private GameObject[] _spawnedWayPoints;

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] int m_CurrentWaypointIndex;
    [SerializeField] float MinCloseDistance = 0.1f;
    private Animator anim;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");   //вынужденная мера, так как монстры спавнятся на карту при старте, и из незаспавненого префаба не получается получить игрока на сцене.        
        anim = gameObject.GetComponent<Animator>();

        if (numOfWaypoints > 0)
            _spawnedWayPoints = SpawnWaypoint();

        if (gameObject.GetComponent<NavMeshAgent>().enabled)
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        
        if (navMeshAgent.isOnNavMesh)
        {
            navMeshAgent.SetDestination(_spawnedWayPoints[0].transform.position);
        }
        else
        {
            Debug.LogError("Agent is not on a NavMesh!", this);
        }
    }

    void Update()
    {


        if ((numOfWaypoints > 0) && (gameObject.GetComponent<NavMeshAgent>().enabled))
        {
            Navigation();
        }

        _distance = (gameObject.transform.position - _player.transform.position).magnitude; //Если подошел игрок

        if (_distance <= _minDistance) {
            PlayerNear();
        }
    }

    GameObject[] SpawnWaypoint()
    {
        GameObject[] point = new GameObject[numOfWaypoints];
        //спавним пути для монстров
        for (int i = 0; i < numOfWaypoints; i++)
        {
            float z_pos_way = Random.Range(WaypointMinZOffset, WaypointMaxZOffset);
            float x_pos_way = Random.Range(WaypointMinXOffset, WaypointMaxXOffset);

            _spawnPositionWaypoint.x = gameObject.transform.position.x + x_pos_way;
            _spawnPositionWaypoint.z = gameObject.transform.position.z + z_pos_way;
            _spawnPositionWaypoint.y = 0f;

            point[i] = Instantiate(_waypointPrefab, _spawnPositionWaypoint, Quaternion.identity);
        }
        return point;
    }

    void PlayerNear() {

        Vector3 relativePos = _player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;

        if (gameObject.GetComponent<NavMeshAgent>().enabled)
            navMeshAgent.SetDestination(_player.transform.position);

    }

    void Navigation() {

        if (navMeshAgent.remainingDistance - navMeshAgent.stoppingDistance <= MinCloseDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % _spawnedWayPoints.Length;
            navMeshAgent.SetDestination(_spawnedWayPoints[m_CurrentWaypointIndex].transform.position);
        }

    }
}
