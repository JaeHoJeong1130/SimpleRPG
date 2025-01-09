using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterGenerator : MonoBehaviour
{
    [SerializeField]
    int _monsterCount = 0;
    int _reserveCount = 0;

    [SerializeField]
    int _keepMonsterCount = 0;

    [SerializeField]
    Vector3 _spawnPos;

    [SerializeField]
    float _spawnRadius = 25.0f;
    [SerializeField]
    float _spawnTime = 5.0f;

    public void AddMonsterCount(int value) { _monsterCount += value; }
    public void SetKeepMonsterCount(int count) { _keepMonsterCount = count; }

    void Start()
    {
        Managers.Game.OnSpawnEvent -= AddMonsterCount;
        Managers.Game.OnSpawnEvent += AddMonsterCount;

        
    }

    void Update()
    { 
    // _monsterCount로만 숫자를 체크해주면 _monsterCount가 늘어나는 도중에
    // UPdate가 계속 실행되면 무한생성될수도있음
        while(_reserveCount + _monsterCount < _keepMonsterCount)
        {
            StartCoroutine("ReserveGenerate");
        }
    }

    IEnumerator ReserveGenerate()
    {
        _spawnPos.Set(72f, 22f, 50f);

        _reserveCount++;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0, _spawnTime));
        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "Minotaur");
        // 갈수 있는 좌표인지 확인하기 위한 nma
        NavMeshAgent nma = obj.GetOrAddComponent<NavMeshAgent>();

        Vector3 randPos;
        while(true)
        {
            // insideUnitSphere : sphere는 3D, 원을 그려서 거기에 있는 랜덤 좌표를 뽑아옴
            Vector3 randDir = UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(0, _spawnRadius);
            randDir.y = 0;
            randPos = _spawnPos + randDir;

            // 갈 수 있나
            NavMeshPath path = new NavMeshPath();
            if (nma.CalculatePath(randPos, path))
                break;
        }
        
        obj.transform.position = randPos;
        _reserveCount--;
    }
    
}
