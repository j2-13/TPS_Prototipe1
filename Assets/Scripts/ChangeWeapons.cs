using UnityEngine;
using System.Collections;

public class ChangeWeapons : MonoBehaviour
{

    public GameObject Weapon1;
    public GameObject Weapon2;
    public Transform spawn;

    // Use this for initialization
    void Start()
    {
        Weapon2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //  接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        //接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {

            //  このコンポーネントを持つGameObjectを破棄する
            Destroy(gameObject);
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            Weapon2.transform.position = spawn.position;
        }
    }

}