using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TrueEnding : MonoBehaviour
{
    public SpriteRenderer fadein;

    private void Start()
    {
        fadein.DOFade(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
