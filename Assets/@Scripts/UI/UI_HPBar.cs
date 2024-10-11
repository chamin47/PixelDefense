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
		// ü�¹ٰ� ���͸� ���󰡵��� ��ġ ����
		transform.position = Camera.main.WorldToScreenPoint(parent.position + Vector3.up * 1.2f);
		// ü�¹ٰ� ī�޶� ���� ȸ������ �ʵ��� ����
		transform.rotation = Quaternion.identity;
	}

	public void SetHpRatio(float ratio)
	{
		GetObject((int)GameObjects.HPBar).GetComponent<Slider>().value = ratio;
	}
}
