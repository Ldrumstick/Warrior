using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerInfos
{
	public int characterID;
	public string playerName;
	public int attackValue;
	public int defValue;
	public int hpValue;
	public int residueHP;
	public int expValue;
	public int residueExp;
	public int level;
}

public class GetPlayerInfos : MonoBehaviour
{
	public GameObject[] characterPrefabs;
	private GameObject character;
	private GameObject characterListGO = null;
	private Vector3 bornPosition = new Vector3(109, 0, 140);
	private void Awake()
	{
		//判断是继续游戏进入还是新游戏进入
		characterListGO = GameObject.Find("CharacterManager");
		if (characterListGO != null)
		{
			//创建新角色
			CreateNewCharacter();
		}
		else
		{
			//读取文档数据
			//还原角色
		}
	}

	/// <summary>
	/// 创建一个新角色
	/// </summary>
	private void CreateNewCharacter()
	{
		CharacterList characterList = characterListGO.GetComponent<CharacterList>();
		character = Instantiate(characterPrefabs[characterList.characterID]);
		character.transform.position = bornPosition;
		PlayerInfo playerinfo = character.GetComponent<PlayerInfo>();
		PlayerInfos newPlayerInfos = new PlayerInfos();
		newPlayerInfos.characterID = characterList.characterID;
		newPlayerInfos.playerName = characterList.characterName;
		newPlayerInfos.attackValue = 10;
		newPlayerInfos.defValue = 10;
		newPlayerInfos.hpValue = 100;
		newPlayerInfos.residueHP = 100;
		newPlayerInfos.level = 1;
		newPlayerInfos.expValue = 100;
		newPlayerInfos.residueExp = 0;
		playerinfo.playerInfo = newPlayerInfos;

		
	}
}
