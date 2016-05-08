using UnityEngine;
using System.Collections;

public class EnemyAttackTrigger : MonoBehaviour
{

    public float DamageAmount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider EnemyAttackHit)
    {
        //接触対象はPlayerタグですか？
        if (EnemyAttackHit.CompareTag("Player"))
        {
            HpBarCtrl.Damage(DamageAmount);
        }

    }
}
