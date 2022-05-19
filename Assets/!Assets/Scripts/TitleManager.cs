using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            audioSource.Play();
            Invoke("ToGameScene", 1.5f);
        }
    }

    void ToGameScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
