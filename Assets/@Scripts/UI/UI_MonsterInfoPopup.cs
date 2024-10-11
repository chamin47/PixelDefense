using UnityEngine;
using TMPro;

public class UI_MonsterInfoPopup : UI_Popup
{
	enum Texts
	{
		NameText,
		GradeText,
		SpeedText,
		HealthText
	}

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		BindText(typeof(Texts));

		return true;
	}

	public void SetInfo(MonsterData data)
	{
		GetText((int)Texts.NameText).text = $"이름: {data.Name}";
		GetText((int)Texts.GradeText).text = $"등급: {data.Grade}";
		GetText((int)Texts.SpeedText).text = $"속도: {data.Speed}";
		GetText((int)Texts.HealthText).text = $"체력: {data.Health}";
	}
}
