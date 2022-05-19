using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public Slider slider_Delayed;
    public Text hp_Text;
    public Text hp_Text_back;
    private Coroutine _coroutine;
    private int _value = 100;   //현재체력
    private int _damage;        //받는 데미지


    // Start is called before the first frame update
    void Start()
    {
        Reset();
        
    }


    public void GetDamage(int damage)
    {
        _damage = damage;
        _value -= _damage;

        if(_value > 0)
        {
            _value = Mathf.Max(0, _value);

            slider.value = _value;

            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(RedSlider(slider_Delayed, _value));

        }
        else
        {
            StopCoroutine(_coroutine);
            slider.value = 0;
            slider_Delayed.value = 0;
            _value = 0;
            slider.fillRect.gameObject.SetActive(false);
            slider_Delayed.fillRect.gameObject.SetActive(false);
        }
        hp_Text.text = _value.ToString() + " / 100";
        hp_Text_back.text = _value.ToString() + " / 100";
    }


    IEnumerator RedSlider(Slider slider, int val)
    {
        yield return new WaitForSeconds (.5f);
        while (slider.value >= val)
        {
            slider.value -= 1;
            yield return null;
        }
    }

    public void Reset()
    {
        _value = 100;
        slider.value = slider_Delayed.value = _value;
        hp_Text.text = _value.ToString() + " / 100";
        hp_Text_back.text = _value.ToString() + " / 100";

        slider.gameObject.SetActive(true);
        slider_Delayed.gameObject.SetActive(true);

        slider.fillRect.gameObject.SetActive(true);
        slider_Delayed.fillRect.gameObject.SetActive(true);

        _coroutine = StartCoroutine(RedSlider(slider_Delayed, _value));
    }
}
