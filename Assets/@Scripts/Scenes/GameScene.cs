using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameScene : BaseScene
{
	void Start()
    {
		Managers.Resource.LoadAllAsync<GameObject>("Prefabs", (key, count, totalCount) =>
		{
			Debug.Log($"{key} {count}/{totalCount}");

			if (count == totalCount)
			{
				StartLoaded();
			}
		});
	}

	SpawningPool _spawningpool;

	void StartLoaded()
	{
		_spawningpool = gameObject.AddComponent<SpawningPool>();

		GameObject player = Managers.Resource.Instantiate("Player.prefab");
		player.transform.position = Vector3.zero;

		Camera.main.GetComponent<CameraController>().Target = player;
	}

	//void StartLoaded2()
	//{
	//	var player = Managers.Object.Spawn<PlayerController>();

	//	for (int i = 0; i < 100; i++)
	//	{
	//		MonsterController mc = Managers.Object.Spawn<MonsterController>(Random.Range(0, 2));
	//		mc.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
	//	}

	//	Camera.main.GetComponent<CameraController>().Target = player.gameObject;
	//}

	public override void Clear()
	{
		throw new System.NotImplementedException();
	}
}
