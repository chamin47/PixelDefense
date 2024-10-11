using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
	public PlayerController Player { get { return Managers.Object?.Player; } }

	Vector2 _moveDir;
	
	public event Action<Vector2> OnMoveChanged;

	public Vector2 MoveDir
	{
		get { return _moveDir; }
		set 
		{ 
			_moveDir = value; 
			OnMoveChanged?.Invoke(_moveDir);
		}
	}
}
