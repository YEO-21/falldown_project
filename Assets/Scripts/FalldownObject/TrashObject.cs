using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TrashObject : FalldownObjectBase
{


    protected override void Update()
    {
        base.Update();

        RollRotation();
    }

    private void RollRotation()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z += 90 * Time.deltaTime;
        transform.eulerAngles = currentRotation;
    }

    protected override void OnCollisionableObjectDetected()
    {
        base.OnCollisionableObjectDetected();

        collisionableObject.OnTrashObjectDetected(m_HitDamage);
    }
}
