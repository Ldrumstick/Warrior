using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
	private Animator animator;
	private CharacterControl characterControl;

	void Start()
	{
		animator = transform.GetComponent<Animator>();
		characterControl = transform.GetComponent<CharacterControl>();
	}

	void Update()
	{
		if (characterControl.playerState == PlayerState.Death)
		{
			return;
		}
		Attack();
	}

	private void Attack()
	{
		
		if (Input.GetKeyDown(KeyCode.Q) )  //Q技能
		{
			characterControl.playerState = PlayerState.Attack;
			animator.SetBool("Run", false);
			animator.SetTrigger("QAttack");
			StartCoroutine("AnimationTimer", AnimationTime.qAttackTime);
		}
		if (Input.GetMouseButtonDown(0)&& UICamera.hoveredObject == null)
		{
			////发射一条射线，判断是否正在操作UI
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//RaycastHit hitInfo;
			//bool isCollider = Physics.Raycast(ray, out hitInfo);
			//Debug.Log(hitInfo.collider.name);
			//if (hitInfo.collider.tag == Tags.ground) 
			//{
				characterControl.playerState = PlayerState.Attack;
				animator.SetBool("Run", false);
				animator.SetTrigger("LeftAttack");
				StartCoroutine("AnimationTimer", AnimationTime.leftAttackTime);
			//}
			
		}
	}

	/// <summary>
	/// 计时器
	/// </summary>
	/// <param name="time"></param>
	/// <returns></returns>
	IEnumerator AnimationTimer(float time)
	{
		yield return new WaitForSeconds(time);
		characterControl.playerState = PlayerState.Idel;
	}
}
