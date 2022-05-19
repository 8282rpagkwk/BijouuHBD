using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FullCamControl : MonoBehaviour
{
    public float moveSpeed;
    public float zoomAmount;
    public GameObject player;
    public GameObject Pguide;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<Camera>().orthographicSize += zoomAmount * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Camera>().orthographicSize -= zoomAmount * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.P))
        {
            Pguide.SetActive(false);
            GetComponent<DOTweenAnimation>().DOPlay();
        }
    }
}
