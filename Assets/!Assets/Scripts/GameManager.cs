using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Guide;
    public GameObject HPBar;
    public Slider Progress;
    public GameObject player;
    public GameObject ScreenHit;
    public GameObject Fade;
    public Transform PlatformPos;
    public Transform GroundPos;
    public Transform BackgroundPos;
    public GameObject[] QuizPlatforms;
    public GameObject[] QuizPanel;
    public GameObject[] Spawner;
    public GameObject[] Grounds;
    public GameObject[] Backgrounds;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    [HideInInspector] public float QuizPos1 = 265f;
    [HideInInspector] public float QuizPos2 = 555f;
    [HideInInspector] public float QuizPos3 = 840f;
    [HideInInspector] public float MAX_LEFT_POS = -18;
    [HideInInspector] public float MAX_RIGHT_POS = 18;
    [HideInInspector] public int stage = 1;
    [HideInInspector] public bool onQuiz = false;
    [HideInInspector] public bool isFinish = false;
    public float ChangeBGoffset = 0;
    public float CreateBGoffset = 0;
    public float CreateGroundoffset = 0;

    [HideInInspector] public SliderController sliderController;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
        Guide.SetActive(true);
    }

    private void Start()
    {
        sliderController = HPBar.GetComponent<SliderController>();
        StartCoroutine(QuizStart());
    }

    IEnumerator QuizStart()
    {
        while (true)
        {
            if (Progress.value > QuizPos3 && !QuizPlatforms[2].activeSelf && Progress.value < QuizPos3 + 5)
            {
                QuizPlatforms[2].SetActive(true);
                QuizPanel[2].SetActive(true);
                break;
            }
            else if (Progress.value > QuizPos2 && !QuizPlatforms[1].activeSelf && Progress.value < QuizPos2 + 5)
            {
                QuizPlatforms[1].SetActive(true);
                QuizPanel[1].SetActive(true);
            }
            else if (Progress.value > QuizPos1 && !QuizPlatforms[0].activeSelf && Progress.value < QuizPos1 + 5)
            {
                QuizPlatforms[0].SetActive(true);
                QuizPanel[0].SetActive(true);
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }
    }

    public void GetDamage(int damage)
    {
        sliderController.GetDamage(damage);
        HPBar.GetComponentInChildren<DOTweenAnimation>().DORestartAllById("Damage");
    }

    public void SpawnNextTile()
    {
        if ((Progress.value > QuizPos1 + ChangeBGoffset && stage == 1) || (Progress.value > QuizPos2 + ChangeBGoffset && stage == 2))
        {
            audioSource.clip = audioClips[stage - 1];
            audioSource.Play();
            stage++;
        }

        GameObject groundObj = Instantiate(Grounds[stage - 1], new Vector3(MAX_RIGHT_POS + CreateGroundoffset, 0, 0), Quaternion.identity);
        groundObj.transform.SetParent(GroundPos);
        GameObject backgroundObj = Instantiate(Backgrounds[stage - 1], new Vector3(MAX_RIGHT_POS + CreateBGoffset, 0, 0), Quaternion.identity);
        backgroundObj.transform.SetParent(BackgroundPos);
    }

    public void ToEndingScene()
    {
        StartCoroutine(EndingScene());
    }

    public IEnumerator EndingScene()
    {
        Fade.SetActive(true);
        player.GetComponent<CapsuleCollider2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        while (true)
        {
            if(player.transform.position.x > 11)
            {
                break;
            }
            player.transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        player.GetComponent<AudioSource>().Play();
    }

    public IEnumerator Hit()
    {
        player.GetComponent<Animator>().SetTrigger("isHit");
        ScreenHit.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        ScreenHit.SetActive(false);
    }
}
