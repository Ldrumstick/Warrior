using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 枚举人物状态
/// </summary>
public enum PlayerState
{
	Idel,  //站立
	Run,  //奔跑
	Attack,  //攻击状态
	UseObject, //使用物品
	Death  //死亡
}

/// <summary>
/// 控制角色移动，跳跃，旋转 
/// </summary>
public class CharacterControl : MonoBehaviour
{

	public float speed = 200f;  //移动速度
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public float sensitivityX = 10f;  //鼠标X方向上的灵敏度
	public float rotationX = 0.0f;  //旋转角度
	public bool isRota = false;
	public float distance = 15.0f;  //摄像机到人物的距离
	public PlayerState playerState = PlayerState.Idel;  //控制人物状态

	private Animator animator;
	private CharacterController charatcterController;
	private bool isGround = true;  //判断是否与地面接触
	private Vector3 moveDirection = Vector3.zero;
	private Camera mainCamera;
	private bool isJumping = false;

	private void Start()
	{
		animator = transform.GetComponent<Animator>();
		charatcterController = transform.GetComponent<CharacterController>();
		mainCamera = Camera.main;
	}

	private void Update()
	{
		if (playerState == PlayerState.Death)
		{
			return;
		}
		#region test
		if (Input.GetKeyDown(KeyCode.X))
		{
			animator.SetTrigger("Death");
			playerState = PlayerState.Death;
		}
		#endregion
		Move();
		Jump();
		FollowPlayer();
	}

	/// <summary>
	/// 角色移动
	/// </summary>
	private void Move()
	{
		#region 角色前后左右移动
		float h = 0;
		float v = 0;
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		if (playerState == PlayerState.Idel)  //人物状态为站立时设置动作
		{
			animator.SetTrigger("Idel");
		}

		if (Mathf.Abs(h) >= 0.1f && (playerState == PlayerState.Idel || playerState == PlayerState.Run))
		{
			animator.SetBool("Run", true);
			playerState = PlayerState.Run;
			//animator.Play("Run");
			charatcterController.SimpleMove(transform.right * h * speed * Time.deltaTime);

		}
		if (Mathf.Abs(v) >= 0.1f && (playerState == PlayerState.Idel || playerState == PlayerState.Run))
		{
			animator.SetBool("Run", true);
			playerState = PlayerState.Run;
			//animator.Play("Run");
			charatcterController.SimpleMove(transform.forward * v * speed * Time.deltaTime);
		}
		if (Mathf.Abs(v) < 0.1f && Mathf.Abs(h) < 0.1f && playerState == PlayerState.Run)
		{
			animator.SetBool("Run", false);
			playerState = PlayerState.Idel;

		}
		#endregion

		#region 角色旋转方向
		if (Input.GetMouseButton(1))
		{
			isRota = true;
		}
		if (Input.GetMouseButtonUp(1))
		{
			isRota = false;
		}
		if (isRota)
		{
			rotationX = Input.GetAxis("Mouse X") * sensitivityX;
			transform.Rotate(0, rotationX, 0);
		}
		#endregion
	}

	/// <summary>
	/// 角色跳跃
	/// </summary>
	private void Jump()
	{
		if (Input.GetButton("Jump") && isGround == true && (playerState == PlayerState.Idel || playerState == PlayerState.Run))
		{

			//animator.SetTrigger("Jump");
			animator.Play("Jump");
			isJumping = true;
			moveDirection.y = jumpSpeed;
			isGround = false;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		charatcterController.Move(moveDirection * Time.deltaTime);

		if (transform.position.y <= 0 && isJumping)
		{
			isGround = true;
			isJumping = false;
			if (playerState == PlayerState.Run)
			{
				animator.SetBool("Run", true);
			}
		}
	}

	/// <summary>
	/// 摄像机跟随人物
	/// </summary>
	private void FollowPlayer()
	{
		mainCamera.transform.position = gameObject.transform.position;  //将摄像机移动到人物的位置
		Vector3 personForward = gameObject.transform.TransformDirection(Vector3.forward); //求得世界坐标中人物的前方
		Vector3 v1 = Vector3.forward + new Vector3(0, -0.5f, 0);  //获得摄像机与人物的角度
		mainCamera.transform.rotation = Quaternion.LookRotation(personForward) * Quaternion.LookRotation(v1);  //将摄像机移动到对应的角度
		mainCamera.transform.Translate(Vector3.back * distance);  //摄像机往后移动
		mainCamera.transform.Translate(Vector3.up * 2, Space.World);  //摄像机往上移动
	}



}
