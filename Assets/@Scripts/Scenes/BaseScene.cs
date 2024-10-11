using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
	public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;

	void Awake()
	{
		Init();
	}

	protected virtual void Init()
	{
		Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
		if (obj == null)
		{
			GameObject eventSystem = Resources.Load<GameObject>("Prefabs/UI/EventSystem");
			Instantiate(eventSystem);
		}			
	}

	public abstract void Clear();
}
