using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _monsterPrefab; //���� ��������
    [SerializeField] private int maxMonsterSpawned = 3; //������������ ���������� ��������

    //****************** TO DO: ������� �������� � ��������� ***********************
    //[SerializeField] private int monsterSpawnTime = 60; //����� ����� ��������� 
    //***************** END TO DO **************************************************
    
    [SerializeField] private float minZOffset = -10f; //����������� �������� �� ��� Z �� ����� ������
    [SerializeField] private float maxZOffset = 10f; //������������ �������� �� ��� Z �� ����� ������

    [SerializeField] private float minXOffset = -10f; //����������� �������� �� ��� X �� ����� ������
    [SerializeField] private float maxXOffset = 10f; //������������ �������� �� ��� X �� ����� ������
    private int monsterCount = 0; // ������� ����������� ��������
    private Vector3 _spawnPosition;

    void Start()
    {
        SpawnMonster();
    }

    // TODO - ������� ����� ���������� ��������� �������� �� �������� ����� ����� ��������� ����.
    //void FixedUpdate()
    //{
    //    SpawnMonster();
    //}

    void SpawnMonster() {

        if (monsterCount < maxMonsterSpawned) {
            //������� ��������
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
