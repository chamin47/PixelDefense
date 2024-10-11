using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
	public enum Scene
	{
		Unknown,
		TitleScene,
		LobbyScene,
		GameScene
	}

	public enum Sound
	{
		Bgm,
		Effect,
		Max,
	}

	public enum UIEvent
	{
		Click,
		Preseed,
		PointerDown,
		PointerUp,
		BeginDrag,
		Drag,
		EndDrag,
	}

	public enum ObjectType
	{
		Player,
		Monster,
		Projectile,
		Env
	}
}
