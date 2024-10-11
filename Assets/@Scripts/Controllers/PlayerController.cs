using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CreatureController
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		MonsterController target = collision.gameObject.GetComponent<MonsterController>();
		if (target == null)
			return;
	}

	public override void OnDamaged(BaseController attacker, int damage)
	{
		base.OnDamaged(attacker, damage);

		Debug.Log($"OnDamaged ! {Hp}");

		// TEMP
		CreatureController cc = attacker as CreatureController;
		cc?.OnDamaged(this, 10000);
	}

	protected override void OnDead()
	{
		base.OnDead();
	}
}
