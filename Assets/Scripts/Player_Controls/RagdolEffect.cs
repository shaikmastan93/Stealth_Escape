using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdolEffect : MonoBehaviour
{
    public Collider[] bodysColliders;
    public Rigidbody[] bodysRbs;
    public Rigidbody bodyRb;

    public void ActivateRagdollEffect()
    {
        foreach (Collider bodyPartCollider in bodysColliders)
            bodyPartCollider.enabled = true;

        foreach (Rigidbody bodyPartRb in bodysRbs)
        {
            bodyPartRb.isKinematic = false;
            bodyPartRb.useGravity = true;
        }
    }
}
