using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EndingManager : MonoBehaviour
{
    string[] EndingText = {
        "비쥬,오늘 이렇게 멀리까지 놀러와줘서 고마워요.",
        "비쥬,완전 짱!",
        "십쥬군,쥬님! 안아줘요~",
        "비쥬,생일파티에 와 준 십쥬군들 고마우니까 한번씩 다 안아줘야지.",
        "비쥬,와락!",
        "비쥬,따뜻하다.",
        "십쥬군,쥬님! 나쁜 생각을 할 것 같아요!!",
        "비쥬,나쁜 생각 안돼! 진짜 어이없어다.",
        "시스템,그렇게 십쥬군들은 비쥬님과 함께 행복한 생일파티를 보냈다.",
        "비쥬,오늘 같이 있어줘서 고맙습니다.",
        "비쥬,다시 돌아가자. 집으로!",
        "십쥬군,쥬바~"
    };

    public TextMeshProUGUI text;
    public Text nameTag;
    public Image nameTagImg;
    public DOTweenAnimation fadein;
    AudioSource audioSource;
    public AudioClip[] clips;
    Color bColor = new Color(206f / 255f, 187f / 255f, 151f / 255f, 255f / 255f);
    Color sColor = new Color(198f / 255f, 187f / 255f, 178f / 255f, 255f / 255f);
    Color nColor = Color.black;

    int index = 0;
    bool isFirst = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        string[] temp = EndingText[index].Split(',');
        nameTag.text = temp[0];
        text.text = temp[1];
        audioSource.clip = clips[index];
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            index++;
            if (index >= EndingText.Length && isFirst)
            {
                isFirst = false;
                fadein.DOPlay();
            }
            else {
                string[] temp = EndingText[index].Split(',');
                nameTag.text = temp[0];
                text.text = temp[1];
                switch (temp[0])
                {
                    case "비쥬":
                        nameTagImg.color = bColor;
                        break;
                    case "십쥬군":
                        nameTagImg.color = sColor;
                        break;
                    case "시스템":
                        nameTagImg.color = nColor;
                        break;
                }
                if (clips[index] != null)
                {
                    audioSource.clip = clips[index];
                    audioSource.Play();
                }
            }
        }
    }

    public void ToCreditScene()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
