using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FishObject : FalldownObjectBase
{
    protected override void OnCollisionableObjectDetected()
    {
        base.OnCollisionableObjectDetected();

        collisionableObject.OnFishObjectDetected(m_RecoveryHp);
    }
}
