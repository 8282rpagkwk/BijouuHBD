using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MovingObject
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        DestroyMovingObject();
    }
}
