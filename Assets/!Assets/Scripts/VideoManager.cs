using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using DG.Tweening;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] videos;
    int index = 0;
    public DOTweenAnimation fade;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.clip = videos[index];
        videoPlayer.SetDirectAudioVolume(0, 0.5f);
        videoPlayer.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (videoPlayer.time + 0.05f > videoPlayer.length)
        {
            if(index == videos.Length - 1)
            {
                fade.DOPlay();
            }
            else
            {
                index++;
                videoPlayer.clip = videos[index];
                videoPlayer.SetDirectAudioVolume(0, 0.3f);
                videoPlayer.Play();
            }
        }
    }

    public void NextScene()
    {
        SceneManager.LoadSceneAsync(4);

    }
}
