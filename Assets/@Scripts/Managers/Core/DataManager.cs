using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
	public Dictionary<int, MonsterData> MonsterDict = new Dictionary<int, MonsterData>();

	public void Init()
	{
		LoadMonsterData();
	}

	void LoadMonsterData()
	{
		List<Dictionary<string, object>> data = CSVReader.Read("MonsterData");

		int id = 0;
		foreach (var item in data)
		{
			MonsterData md = new MonsterData();
			md.Name = item["Name"].ToString();
			md.Grade = item["Grade"].ToString();
			md.Speed = float.Parse(item["Speed"].ToString());
			md.Health = int.Parse(item["Health"].ToString());

			MonsterDict.Add(id, md);
			id++;
		}
	}
}

public class MonsterData
{
	public string Name;
	public string Grade;
	public float Speed;
	public int Health;
}
