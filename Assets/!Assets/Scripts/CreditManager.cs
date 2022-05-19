using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Video;

public class CreditManager : MonoBehaviour
{
    public GameObject[] Cams;
    //public DOTweenAnimation fadein;
    //public DOTweenAnimation fadeout;
    public SpriteRenderer transition;
    public float interval = 0;
    public float fadetime = 0;
    public GameObject guide;
    public GameObject hidetext;
    int index = 0;

    private void Start()
    {
        StartCoroutine(EndingCredit());
    }

    IEnumerator EndingCredit()
    {
        while (true)
        {
            transition.DOFade(0, fadetime);
            if (index == Cams.Length - 1)
            {
                hidetext.SetActive(true);
                yield return new WaitForSecondsRealtime(fadetime);
                guide.SetActive(true);
                break;
            }
            else {
                yield return new WaitForSecondsRealtime(interval);
                transition.DOFade(1, fadetime);
                yield return new WaitForSecondsRealtime(fadetime);
                index++;
                ChangeCam();
            }
        }
        //transition.color = Color.black;
    }

    public void ChangeCam()
    {
        if (index == 4)
        {
            hidetext.SetActive(false);
        }
        Cams[index - 1].SetActive(false);
        Cams[index].SetActive(true);
    }
}
