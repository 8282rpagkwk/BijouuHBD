using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    PlatformEffector2D pe;
    [SerializeField]
    bool playerIsOn = false;

    private void Start()
    {
        pe = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlatformReset();
        }
        else if (Input.GetKeyDown(KeyCode.S) && playerIsOn)
        {
            DownJump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerIsOn = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerIsOn = false;
    }

    void DownJump()
    {
        pe.rotationalOffset = 180;
    }

    void PlatformReset()
    {
        pe.rotationalOffset = 0;
    }
}
