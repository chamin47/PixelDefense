using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameScene : MonoBehaviour
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

	void StartLoaded()
	{
		GameObject player = Managers.Resource.Instantiate("Player.prefab");
		player.AddComponent<CameraController>();

		Camera.main.GetComponent<CameraController>().Target = player;
	}
}
