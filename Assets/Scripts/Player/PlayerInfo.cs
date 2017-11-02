using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
	public static PlayerInfo _instance;
	public PlayerInfos playerInfo = new PlayerInfos();
	public int plusAttack = 0;
	public int plusDef = 0;
	public int plusHP = 0;

	private void Awake()
	{
		_instance = this;
	}

}
