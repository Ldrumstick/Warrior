using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameSenceUI : MonoBehaviour
{

	private GameObject helpLabelGO;

	private void Awake()
	{
		helpLabelGO = transform.Find("Button/HelpLabel").gameObject;
		helpLabelGO.SetActive(false);

	}

	/// <summary>
	/// NewGameButton按钮事件，开始新游戏
	/// </summary>
	public void NewGameButtonClick()
	{
		SceneManager.LoadScene(1);  //加载创建角色界面
	}

	/// <summary>
	/// LoadGameButton按钮事件，读取存档
	/// </summary>
	public void LoadGameButtonClick()
	{ }

	/// <summary>
	/// ExitGameButton按钮事件，退出游戏
	/// </summary>
	public void ExitGameButtonClick()
	{
		Application.Quit();  //退出游戏
	}

	/// <summary>
	/// HelpButtonClick显示帮助界面
	/// </summary>
	public void HelpButtonClick()
	{
		helpLabelGO.SetActive(true);
	}

	/// <summary>
	/// 关闭帮助界面
	/// </summary>
	public void CloseHelpLabelButtonClick()
	{
		helpLabelGO.SetActive(false);
	}
}
