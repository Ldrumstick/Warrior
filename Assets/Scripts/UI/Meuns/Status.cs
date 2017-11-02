using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
	private bool isShow = false;  //记录面板是否显示
	private TweenPosition tween;

	private UILabel nameLabel;
	private UILabel levelLabel;
	private UILabel hpLabel;
	private UILabel attackLabel;
	private UILabel defLabel;


	
	private void Awake()
	{
		tween = this.GetComponent<TweenPosition>();

		//获得显示更新数据用的Label
		nameLabel = transform.Find("Name").GetComponent<UILabel>();
		levelLabel = transform.Find("Level").GetComponent<UILabel>();
		hpLabel = transform.Find("HP").GetComponent<UILabel>();
		attackLabel = transform.Find("Attack").GetComponent<UILabel>();
		defLabel = transform.Find("Def").GetComponent<UILabel>();
	}

	void Start () {
		
	}
	
	void Update () {
		
	}

	/// <summary>
	/// 处理Status界面的显示与隐藏
	/// </summary>
	public void Show()
	{
		if(isShow ==false)
		{
			tween.PlayForward();
			UpdateInfo();
			isShow = true; 
		}else if(isShow == true)
		{
			tween.PlayReverse();
			isShow = false;
		}
		
	}
	/// <summary>
	/// 更新面板内的信息
	/// </summary>
	public void UpdateInfo()
	{
		nameLabel.text = PlayerInfo._instance.playerInfo.playerName;
		levelLabel.text = PlayerInfo._instance.playerInfo.level.ToString();
		hpLabel.text = (PlayerInfo._instance.playerInfo.hpValue + PlayerInfo._instance.plusHP).ToString() + "/" + PlayerInfo._instance.playerInfo.residueHP;
		attackLabel.text = (PlayerInfo._instance.playerInfo.attackValue + PlayerInfo._instance.plusAttack).ToString();
		defLabel.text = (PlayerInfo._instance.plusDef + PlayerInfo._instance.playerInfo.defValue).ToString();
	}
}
