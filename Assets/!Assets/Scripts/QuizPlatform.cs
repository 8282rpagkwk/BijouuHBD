using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuizPlatform : MovingObject
{
    float timer = 10;

    public Text timerText;

    const float DISABLE_POINT = -34;

    private void OnEnable()
    {
        timerText.text = "10";
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(transform.position.x < DISABLE_POINT)
        {
            gameObject.SetActive(false);
        }

        if (timerText.text != "")
        {
            if (timer < 0)
            {
                CloseQuiz();
            }
            else
            {
                Counting();
            }
        }
    }

    void Counting()
    {
        timer -= Time.deltaTime;
        timerText.text = $"{(int)timer}";
    }

    void CloseQuiz()
    {
        timerText.text = "";
        foreach(GameObject obj in gm.QuizPanel)
        {
            if (obj.activeSelf)
            {
                obj.transform.GetChild(0).gameObject.GetComponent<DOTweenAnimation>().DORestartById("Close");
            }
        }
    }

    private void OnDisable()
    {
        timer = 10;
        transform.position = new Vector3(gm.MAX_RIGHT_POS, 0, 0);
    }
}
