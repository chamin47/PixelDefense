using System.Collections;
using UnityEngine;

public class PlayerController : CreatureController
{
	Coroutine _coAttack;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		StartAttack();

		return true;
	}

	void StartAttack()
	{
		if (_coAttack != null)
			StopCoroutine(_coAttack);

		_coAttack = StartCoroutine(CoAttack());
	}

	IEnumerator CoAttack()
	{
		while (true)
		{
			Attack();
			yield return new WaitForSeconds(1.0f);
		}
	}

	void Attack()
	{
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5.0f); // �ʿ��� ��� �ݰ� ����
		foreach (var hitCollider in hitColliders)
		{
			MonsterController monster = hitCollider.GetComponent<MonsterController>();
			if (monster != null)
			{
				monster.OnDamaged(this, 100);
			}
		}
	}
}
