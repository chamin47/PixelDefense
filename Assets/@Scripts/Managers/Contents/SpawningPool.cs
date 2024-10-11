using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawningPool : MonoBehaviour
{
    // 리스폰 주기는?
    // 몬스터 최대 개수는?
    // 스톱?
    float _spawnInterval = 0.1f;
    int __maxMonsterCount = 100;
    Coroutine _coUpdateSpawningPool;

    void Start()
	{
		_coUpdateSpawningPool = StartCoroutine(GetCoUpdateSpawningPool());
	}

	IEnumerator GetCoUpdateSpawningPool()
	{
		while (true)
        {
            TrySpawn();
            yield return new WaitForSeconds(_spawnInterval);
        }
	}

	private void TrySpawn()
	{
		int monsterCount = Managers.Object.Monsters.Count;
		if (monsterCount >= __maxMonsterCount)
			return;

		// TEMP : DataID ?
		MonsterController mx = Managers.Object.Spawn<MonsterController>(Random.Range(0, 2));
		mx.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
	}
}
