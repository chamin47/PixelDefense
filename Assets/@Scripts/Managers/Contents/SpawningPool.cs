using System.Collections;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
	int _currentMonsterIndex = 0;

	void Start()
	{
		MonsterController.OnMonsterDead += OnMonsterDead;
		TrySpawn();
	}

	void OnDestroy()
	{
		MonsterController.OnMonsterDead -= OnMonsterDead;
	}

	void OnMonsterDead()
	{
		TrySpawn();
	}


	private void TrySpawn()
	{
		int monsterCount = Managers.Object.Monsters.Count;
		if (monsterCount > 0)
			return;

		int monsterDataCount = Managers.Data.MonsterDict.Count;
		int templateID = _currentMonsterIndex % monsterDataCount;

		MonsterController mc = Managers.Object.Spawn<MonsterController>(templateID);
		mc.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));

		_currentMonsterIndex++;
	}
}
