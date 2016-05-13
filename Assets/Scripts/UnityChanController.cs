using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UnityChanController : MonoBehaviour 
{
	
	private Animator animator;
	private float Yrotation;
	private float nextjump;
	private int doWalkId;
	private int doRunId;
	private int doBackWalkId;
	private bool jump;
	private float jumpRate = 3;
	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
		doWalkId = Animator.StringToHash ("Do Walk");
		doRunId = Animator.StringToHash ("Do Run");
		doBackWalkId = Animator.StringToHash ("Do BackWalk");

		jump = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//歩く
		if (Input.GetKey(KeyCode.W)) 
		{
			animator.SetBool(doWalkId, true);
			transform.position += transform.forward * 0.02f; // 移動

		}else{
			animator.SetBool(doWalkId, false);
		}

		//走る
		if (Input.GetKey(KeyCode.W )&& Input.GetKey (KeyCode.LeftShift)) 
		{
			animator.SetBool(doRunId,true);
			transform.position += transform.forward * 0.05f; // 移動

		}else{
			animator.SetBool(doRunId, false);
		}

		//後ろ歩き
		if (Input.GetKey(KeyCode.S)) 
		{
			animator.SetBool(doBackWalkId, true);
			transform.position -= transform.forward * 0.02f; // 移動
			
		}else{
			animator.SetBool(doBackWalkId, false);
		}

		if(Input.GetKey(KeyCode.A))
		{
			Yrotation+=70*Time.deltaTime;
			transform.rotation=Quaternion.Euler(0,Yrotation,0);
		}

		if(Input.GetKey(KeyCode.D))
		{
			Yrotation-=70*Time.deltaTime;
			transform.rotation=Quaternion.Euler(0,Yrotation,0);
		}

		if (Input.GetKeyDown(KeyCode.Space)&& (Time.time > nextjump ))
		{
			nextjump = Time.time + jumpRate; //3秒足す) 		
			jump = true;
			animator.SetBool("Jumping", jump);
			Invoke ("Jumping",2);
		}

		if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) && (Time.time > nextjump ))
		{
			nextjump = Time.time + jumpRate; //3秒足す) 		
			jump = true;
			animator.SetBool("Jumping", jump);
			Invoke ("Jumping",2);
		}
	}

	private void Jumping()
	{
		if (jump == true)
		{
			jump = false;
			animator.SetBool("Jumping", jump);
		}
	}
}
