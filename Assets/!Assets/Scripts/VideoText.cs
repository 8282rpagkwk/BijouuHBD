using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoText : MonoBehaviour
{
    string[] sipjugoonText = {"비쥬님! 잠깐만요!!", "친구들이 편지를 보냈는데 보고 가셔야죠!!"};
    public TextMeshProUGUI text;
    public GameObject videoManager;
    public GameObject videoPlayer;
    public AudioSource audioSource;
    void Start()
    {
        StartCoroutine(ShowText());
        text.gameObject.SetActive(true);
        text.text = "";
    }

    IEnumerator ShowText()
    {
        yield return new WaitForSecondsRealtime(4.0f);
        text.text = sipjugoonText[0];
        yield return new WaitForSecondsRealtime(2.0f);
        text.text = sipjugoonText[1];
        yield return new WaitForSecondsRealtime(3.0f);
        GetComponent<Animator>().SetBool("startVideo", true);
        yield return new WaitForSecondsRealtime(1.0f);
        text.gameObject.SetActive(false);
        audioSource.Stop();
        videoManager.SetActive(true);
        videoPlayer.SetActive(true);
    }
}
