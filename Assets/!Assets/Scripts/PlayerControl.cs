using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rig;
    CapsuleCollider2D coll;
    Animator anim;
    [SerializeField] bool isGround = false;
    [SerializeField] bool isPlatform = false;
    bool isFinish = false;
    public bool isLive = true;
    public float jumpPower = 0;
    public int hp = 100;
    GameManager gm;
    public float timeScale = 0;
    AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip OSound;
    public AudioClip XSound;
    public GameObject reviveObj;

    const float QuizPos1 = 265f;
    const float QuizPos2 = 555f;
    const float QuizPos3 = 840f;
    const float Finish = 1150f;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        gm = GameManager.instance;
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(AddDistance());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && (isGround || isPlatform))
        {
            Jump();
        }

        switch (gm.Progress.value)
        {
            case QuizPos1:
                timeScale = 0.3f;
                gm.onQuiz = true;
                break;
            case QuizPos1+40:
                timeScale = 0.15f;
                gm.onQuiz = false;
                gm.Spawner[0].SetActive(false);
                gm.Spawner[1].SetActive(true);
                break;
            case QuizPos2:
                timeScale = 0.3f;
                gm.onQuiz = true;
                break;
            case QuizPos2 + 40:
                timeScale = 0.2f;
                gm.onQuiz = false;
                gm.Spawner[1].SetActive(false);
                gm.Spawner[2].SetActive(true);
                break;
            case QuizPos3:
                gm.onQuiz = true;
                break;
            case QuizPos3 + 40:
                gm.onQuiz = false;
                break;
            case Finish:
                if (!isFinish)
                {
                    gm.Spawner[2].SetActive(false);
                    gm.isFinish = true;
                    gm.ToEndingScene();
                }
                break;
        }

        if (hp <= 0 && isLive)
        {
            isLive = false;
            audioSource.Stop();
            StartCoroutine(Revive());
        }
    }

    void Jump()
    {
        isGround = false;
        isPlatform = false;
        anim.SetBool("isGround", false);
        audioSource.Stop();
        audioSource.PlayOneShot(jumpSound);
        rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
            anim.SetBool("isGround", true);
            audioSource.Play();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isPlatform = true;
            anim.SetBool("isGround", true);
            audioSource.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
            anim.SetBool("isGround", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = false;
            anim.SetBool("isGround", false);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isPlatform = false;
            anim.SetBool("isGround", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "DropCheck":
                coll.isTrigger = true;
                break;
            case "DamageZone":
                coll.isTrigger = false;
                gm.GetDamage(10);
                hp -= 10;
                transform.position = new Vector3(-6, -2, 0);
                break;
            case "A1":
                showOX();
                correctCheck(2);
                break;
            case "A2":
                showOX();
                correctCheck(0);
                break;
            case "A3":
                showOX();
                correctCheck(1);
                break;
        }
    }
    
    IEnumerator AddDistance()
    {
        while (true)
        {
            if(Time.timeScale != 0) gm.Progress.value += 1.0f;
            yield return new WaitForSecondsRealtime(timeScale);
        }
    }

    void showOX()
    {
        foreach (GameObject obj in gm.QuizPanel)
        {
            if (obj.activeSelf)
            {
                obj.GetComponent<QuizControl>().ShowResult();
            }
        }
    }

    void correctCheck(int panel)
    {
        if (!gm.QuizPanel[panel].activeSelf)
        {
            gm.GetDamage(10);
            Camera.main.gameObject.GetComponent<DOTweenAnimation>().DORestartById("Damage");
            StartCoroutine(gm.Hit());
            gm.audioSource.PlayOneShot(XSound);
            anim.SetTrigger("isHit");
            hp -= 10;
        }
        else
        {
            gm.audioSource.PlayOneShot(OSound);
        }
    }

    IEnumerator Revive()
    {
        reviveObj.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(5.0f);
        hp = 100;
        gm.sliderController.Reset();
        reviveObj.SetActive(false);
        isLive = true;
        audioSource.Play();
        Time.timeScale = 1;
    }
}