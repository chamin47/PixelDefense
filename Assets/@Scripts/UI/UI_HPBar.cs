using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar : UI_Base
{
	enum GameObjects
	{
		HPBar
	}

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		Bind<GameObject>(typeof(GameObjects));
		return true;
	}

	private void LateUpdate()
	{
		if (Camera.main == null)
			return;

		Transform parent = transform.parent;
		// 체력바가 몬스터를 따라가도록 위치 설정
		transform.position = Camera.main.WorldToScreenPoint(parent.position + Vector3.up * 1.2f);
		// 체력바가 카메라를 따라 회전하지 않도록 설정
		transform.rotation = Quaternion.identity;
	}

	public void SetHpRatio(float ratio)
	{
		GetObject((int)GameObjects.HPBar).GetComponent<Slider>().value = ratio;
	}
}
