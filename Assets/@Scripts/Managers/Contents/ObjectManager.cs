using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager
{
    public PlayerController Player { get; private set; }
    public HashSet<MonsterController> Monsters { get; } = new HashSet<MonsterController>();
    public HashSet<ProjectileController> Projectiles { get; } = new HashSet<ProjectileController>();

	public Transform MonsterTransform
	{
		get
		{
			GameObject root = GameObject.Find("@Monster");
			if (root == null)
				root = new GameObject { name = "@Monster" };
			return root.transform;
		}
	}

	public ObjectManager()
	{
		Init();
	}

	public void Init()
	{

	}

	public void Clear()
	{
		Monsters.Clear();	
		Projectiles.Clear();
	}

	public T Spawn<T>(int templateID = 0) where T : BaseController
	{
		System.Type type = typeof(T);

		if (type == typeof(PlayerController))
		{
			GameObject go = Managers.Resource.Instantiate("Player.prefab", pooling: true);
			go.name = "Player";

			PlayerController pc = go.GetOrAddComponent<PlayerController>();
			Player = pc;
			pc.Init();

			return pc as T;
		}
		else if (type == typeof(MonsterController))
		{
			// DataManager���� MonsterData ��������
			MonsterData md = Managers.Data.MonsterDict[templateID];

			// ������ �ε� (������ �̸��� ���� �̸��� �����ϴٰ� ����)
			string prefabName = md.Name;

			GameObject go = Managers.Resource.Instantiate(prefabName + ".prefab", pooling: true);
			if (go == null)
			{
				Debug.LogError($"������ �ε� ����: {prefabName}");
				return null;
			}

			MonsterController mc = go.GetOrAddComponent<MonsterController>();
			mc.SetMonsterData(md); // MonsterData �Ҵ�
			mc.Init();

			Monsters.Add(mc);
			return mc as T;
		}

		return null;
	}


	public void Despawn<T>(T obj) where T : BaseController
    {
        System.Type type = typeof(T);

        if (type == typeof(PlayerController))
        {
            // ?
        }
        else if (type == typeof(MonsterController))
        {
            Monsters.Remove(obj as MonsterController);
            Managers.Resource.Destroy(obj.gameObject);
        }
        else if (type == typeof(ProjectileController))
        {
            Projectiles.Remove(obj as ProjectileController);
            Managers.Resource.Destroy(obj.gameObject);
        }
    }
}
