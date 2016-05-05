using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UnityChanController : MonoBehaviour 
{
	
	private Animator animator;
	private int doWalkId;
	private int doRunId;
	private int doBackWalkId;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
		doWalkId = Animator.StringToHash ("Do Walk");
		doRunId = Animator.StringToHash ("Do Run");
		doBackWalkId = Animator.StringToHash ("Do BackWalk");	
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

	}

}
