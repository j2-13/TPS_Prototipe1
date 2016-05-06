using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class HpBarCtrl : MonoBehaviour
{

    Slider _slider;
    public UnityEngine.UI.Text hp;
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    float _hp = 0;
    void Update()
    {
        // HP上昇
        if (_hp < _slider.maxValue)
        {
        _hp +=1f;
        // HPゲージに値を設定
        _slider.value = _hp;
        hp.text = _hp + "/100";
        }

     
    }
}