using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterList : MonoBehaviour {

	public GameObject[] characterArray;
	public UILabel uiLabel;
	public string characterName = null;
	public int characterID = 0;
	
	private void Awake()
	{
		foreach (var item in characterArray)
		{
			item.SetActive(false);
		}
		characterArray[0].SetActive(true);
	}	
	

	//按钮管理
	/// <summary>
	/// 下一个角色按钮
	/// </summary>
	public void NextCharacterButtonClick()
	{
		characterArray[characterID].SetActive(false);
		characterID++;
		characterID = characterID % characterArray.Length;
		characterArray[characterID].SetActive(true);
	}

	/// <summary>
	/// 上一个角色按钮
	/// </summary>
	public void BackCharacterButtonClick()
	{
		characterArray[characterID].SetActive(false);
		characterID--;
		characterID = characterID ==-1 ? characterArray.Length -1:characterID;
		characterArray[characterID].SetActive(true);
	}

	/// <summary>
	/// 按下OK键获得名字与角色ID，并加载下一个场景
	/// </summary>
	public void OKButtonClick()
	{
		if(uiLabel.text != null && uiLabel.text != "Input your name" && !uiLabel.text.Contains(" "))
		{
			characterName = uiLabel.text;
			DontDestroyOnLoad(gameObject);
			SceneManager.LoadScene(2);
		}
	}
}
