using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] GrowFrog GF;
    [SerializeField] UIManagment UIM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Frog"))
        {
            Debug.Log("Game won!");
            UIM.Paused = true;
            StartCoroutine(GF.WinGameSounds());
        }
    }
}
