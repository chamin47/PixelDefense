using System;
using UnityEngine;

public class MonsterController : CreatureController
{
	public MonsterData MonsterData { get; private set; }
	public UI_HPBar HealthBar { get; private set; }
	public static event Action OnMonsterDead;

	Coroutine _coDotDamage;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		_ObjectType = Define.ObjectType.Monster;

		// 몬스터 데이터 초기화
		Hp = MonsterData.Health;
		maxHp = MonsterData.Health;
		_speed = MonsterData.Speed;

		// 체력 바 초기화
		GameObject go = Managers.Resource.Instantiate("UI/WorldSpace/UI_HPBar", transform);
		go.name = "HPBar";
		HealthBar = go.GetOrAddComponent<UI_HPBar>();
		HealthBar.Init();
		HealthBar.SetHpRatio(1.0f); // 초기 체력 비율 설정

		return true;
	}

	public void SetMonsterData(MonsterData data)
	{
		MonsterData = data;
	}

	public override void OnDamaged(BaseController attacker, int damage)
	{
		base.OnDamaged(attacker, damage);

		float ratio = Hp / (float)maxHp;
		HealthBar.SetHpRatio(ratio);
	}

	protected override void OnDead()
	{
		base.OnDead();

		if (_coDotDamage != null)
			StopCoroutine(_coDotDamage);
		_coDotDamage = null;

		Managers.Resource.Destroy(HealthBar.gameObject);
		Managers.Object.Despawn(this);

		// 몬스터가 죽었음을 알림
		OnMonsterDead?.Invoke();
	}

	void FixedUpdate()
	{
		PlayerController pc = Managers.Object.Player;
		if (pc == null)
			return;

		Vector3 dir = pc.transform.position - transform.position;
		Vector3 newPos = transform.position + dir.normalized * _speed * Time.deltaTime;
		GetComponent<Rigidbody2D>().MovePosition(newPos);

		GetComponent<SpriteRenderer>().flipX = dir.x > 0;
	}

	void OnMouseDown()
	{
		UI_MonsterInfoPopup popup = Managers.UI.ShowPopupUI<UI_MonsterInfoPopup>();
		popup.SetInfo(MonsterData);
	}

	// 필요에 따라 OnCollisionEnter2D 등 다른 메서드도 포함
}
