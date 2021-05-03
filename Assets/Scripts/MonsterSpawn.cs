using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject _monsterPrefab; //кого спавнить
    [SerializeField] private GameObject _waypointPrefab; //Точки пути
    [SerializeField] private int numOfWaypoints = 3;

    [SerializeField] private int maxMonsterSpawned = 3; //максимальное количество монстров

    //****************** TO DO: респаун монстров с задержкой ***********************
    //[SerializeField] private int monsterSpawnTime = 60; //время между респауном 
    //***************** END TO DO **************************************************
    
    [SerializeField] private float minZOffset = -10f; //минимальное смещение по оси Z от точки спавна
    [SerializeField] private float maxZOffset = 10f; //максимальное смещение по оси Z от точки спавна

    [SerializeField] private float minXOffset = -10f; //минимальное смещение по оси X от точки спавна
    [SerializeField] private float maxXOffset = 10f; //максимальное смещение по оси X от точки спавна
    private int monsterCount = 0; // счетчик заспавненых монстров
    private Vector3 _spawnPosition;
    private Vector3 _spawnPositionWaypoint;

    void Start()
    {
        SpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnMonster(); 
    }

    void SpawnMonster() {

        if (monsterCount < maxMonsterSpawned) {

            //спавним монстров
            float z_pos = Random.Range(minZOffset, maxZOffset);
            float x_pos = Random.Range(minXOffset, maxXOffset);

            _spawnPosition.x = gameObject.transform.position.x + x_pos;
            _spawnPosition.z = gameObject.transform.position.z + z_pos;
            _spawnPosition.y = gameObject.transform.position.y;

            var spawned = Instantiate(_monsterPrefab, _spawnPosition, Quaternion.identity);

            //спавним пути для монстров
            for (int i=0; i < numOfWaypoints; i++)
            {

                float z_pos_way = Random.Range(minZOffset, maxZOffset);
                float x_pos_way = Random.Range(minXOffset, maxXOffset);

                _spawnPositionWaypoint.x = gameObject.transform.position.x + x_pos_way;
                _spawnPositionWaypoint.z = gameObject.transform.position.z + z_pos_way;
                _spawnPositionWaypoint.y = gameObject.transform.position.y;

                var spawnedWaypoint = Instantiate(_waypointPrefab, _spawnPositionWaypoint, Quaternion.identity);

               // if (spawned.GetComponent<MoveController>().isActiveAndEnabled) { 
                //здесь надо закинуть в массив _waypoint из MoveСontroller обьекты spawnedWaypoint. Как - не знаю...
               // }



            }
            monsterCount++;
            SpawnMonster();
        }


    }
}
