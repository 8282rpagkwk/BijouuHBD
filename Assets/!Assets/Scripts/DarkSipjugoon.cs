using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSipjugoon : MonoBehaviour
{
    Animator anim;
    bool isFind = false;
    public Transform rayPos;

    private void OnEnable()
    {
        isFind = false;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.DrawRay(rayPos.position, Vector2.left * 5, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(rayPos.position, Vector2.left, 5);

        if (hit)
        {
            if (hit.transform.gameObject.tag == "Player" && !isFind)
            {
                isFind = true;
                anim.SetBool("isFind", true);
            }
        }
    }

    private void OnDisable()
    {
        if(anim != null)
        anim.SetBool("isFind", false);
    }
}
