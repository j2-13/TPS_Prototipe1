using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject target;
    public Transform HumanTypeEnemyPosition;
    NavMeshAgent agent;
    Animator animator;
    public float DamageAmount;

    private bool attack = false;
    //距離関係
    private float distance;
    private float mindistance = 5;
    //攻撃関係
    private float nextAttack;
    private float AttackRate = 3;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        HumanTypeEnemyPosition = transform;
	}
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(target.transform.position, HumanTypeEnemyPosition.position);

        if ((distance < mindistance) && (Time.time > nextAttack ) )
        {
            nextAttack = Time.time + AttackRate; //3秒足す
            attack = true;
            animator.SetBool("Attack", attack);
            Invoke("Attack", 2);
        }

        if (distance < 1.5f) {
            animator.SetFloat("Speed", 0);
        }
        else {
            agent.destination = target.transform.position;
            animator.SetFloat("Speed", agent.velocity.magnitude - 1.5f);
        }
	}

    private void Attack()
    {
        if (attack == true)
        {
            attack = false;
            animator.SetBool("Attack", attack);
        }
    }


}
