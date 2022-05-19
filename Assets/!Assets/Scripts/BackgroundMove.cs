using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    const float MAX_LEFT_POS = -17.85f;
    const float RESET_POS = 0;
    public float moveSpeed = 0;
    public GameObject[] Backgrounds;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    void FixedUpdate()
    {
        Move();
        Reposition();
    }

    void Reposition()
    {
        if (transform.position.x < MAX_LEFT_POS)
        {
            if((gm.Progress.value > gm.QuizPos1 + 40 && gm.stage == 1) ||
                (gm.Progress.value > gm.QuizPos2 + 40 && gm.stage == 2))
            {
                Backgrounds[gm.stage - 1].SetActive(false);
                Backgrounds[gm.stage].SetActive(true);
                gm.stage++;
                gm.SpawnNextTile();
                Debug.Log($"Background change - SpawnGround - {gm.Grounds[gm.stage - 1].name} 생성");
            }
            transform.position = new Vector2(RESET_POS, 0);
        }
    }

    void Move()
    {
        transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
    }
}
