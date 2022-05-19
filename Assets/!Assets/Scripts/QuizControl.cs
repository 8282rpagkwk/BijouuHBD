using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizControl : MonoBehaviour
{
    [Header("UI")]
    public Text Qtext;
    public Text A1text;
    public Text A2text;
    public Text A3text;
    [Header("Content")]
    public string Qinput;
    public string A1input;
    public string A2input;
    public string A3input;
    public GameObject[] OX;

    private void Start()
    {
        Qtext.text = Qinput;
        A1text.text = A1input;
        A2text.text = A2input;
        A3text.text = A3input;
    }

    public void ShowResult()
    {
        foreach(GameObject obj in OX)
        {
            obj.SetActive(true);
        }
    }
}
