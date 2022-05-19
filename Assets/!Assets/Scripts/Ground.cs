using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MovingObject
{
    bool isFirst = false;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        DestroyMovingObject();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isFirst)
        {
            isFirst = true;
            gm.SpawnNextTile();
        }
    }
}
