using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float moveSpeed = 0;
    protected GameManager gm;

    protected void Start()
    {
        gm = GameManager.instance;
    }

    protected virtual void FixedUpdate()
    {
        if (!gm.isFinish)
        {
            Move();
        }
    }

    protected void Move()
    {
        transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
    }

    protected void DestroyMovingObject()
    {
        if (transform.position.x < gm.MAX_LEFT_POS)
        {
            Destroy(this.gameObject);
        }
    }

    protected void DisableMovingObject()
    {
        if (transform.position.x < gm.MAX_LEFT_POS)
        {
            gameObject.SetActive(false);
        }
    }
}
