using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _monsterPrefab; //кого спавнить
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

    void Start()
    {
        SpawnMonster();
    }

    // TODO - Спавнер после реализации механизма респауна по таймауту нужно будет перенести сюда.
    //void FixedUpdate()
    //{
    //    SpawnMonster();
    //}

    void SpawnMonster() {

        if (monsterCount < maxMonsterSpawned) {
            //спавним монстров
            float z_pos = Random.Range(minZOffset, maxZOffset);
            float x_pos = Random.Range(minXOffset, maxXOffset);

            _spawnPosition.x = gameObject.transform.position.x + x_pos;
            _spawnPosition.z = gameObject.transform.position.z + z_pos;
            _spawnPosition.y = 0;

            var spawned = Instantiate(_monsterPrefab, _spawnPosition, Quaternion.identity);

            monsterCount++;
            SpawnMonster();
        }
    }
}
