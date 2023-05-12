using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position=new Vector3(0f, 1f, -12f);
    }
}
