using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeunsUI : MonoBehaviour {
	private Status status;

	private void Awake()
	{
		status = GameObject.Find("Status").GetComponent<Status>();
	}

	/// <summary>
	/// 显示人物属性面板
	/// </summary>
	public void StatusButtonClick()
	{
		status.Show();
	 }

	/// <summary>
	/// 显示装备面板
	/// </summary>
	public void EquipmentButton()
	{ }

	/// <summary>
	/// 显示背包面板
	/// </summary>
	public void InventoryButton()
	{ }
}
