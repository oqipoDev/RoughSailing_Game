using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ForceToPrefabCenter : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        if (transform.localPosition != Vector3.zero)
        {
            transform.localPosition = Vector3.zero;
            Debug.LogWarning("Cannot move models that belong to Prefabs!");
        }
    }
}
