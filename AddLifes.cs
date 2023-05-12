using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLifes : MonoBehaviour
{
    private TurnToLeaf TTL;
    [SerializeField] int LifeState = 0;
    [SerializeField] TriggersAndBools TAB;
    [SerializeField] GameObject frog;
    [SerializeField] Transform frogTrans;
    [SerializeField] GameObject blackBack;
    private void Update()
    {
        transform.LookAt(frogTrans);
        Vector3 euler = transform.localEulerAngles;
        euler.x = 0;
        euler.z = 0;
        transform.localEulerAngles = euler;
    }

    private void OnTriggerEnter(Collider other)
    {
        TTL = other.gameObject.GetComponent<TurnToLeaf>();
        if (other.gameObject.CompareTag("Frog"))
        {
            if (LifeState == 1)
            {
                TAB.SmallBool = true;
            }
            if (LifeState == 2)
            {
                TAB.MediumBool = true;
            }
            if (LifeState == 3)
            {
                TAB.BigBool = true;
            }
            frog = other.gameObject;
        }
        StartCoroutine(EndIt());
    }
    IEnumerator EndIt()
    {
        TTL.leafing = true;
        blackBack.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);
        //place where frog gets placed after getting new life up
        frog.gameObject.transform.position = new Vector3(0, 1, -12);
        TTL.leafing = false;
        yield return new WaitForSeconds(1.1f);
        blackBack.SetActive(false);
        Destroy(gameObject);
    }
}
