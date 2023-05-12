using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFrog : MonoBehaviour
{
    private GrowFrog GF;
    public int leafValue;
    [SerializeField] GameObject audioObject;
    private SoundEngine SE;

    private void Start()
    {
        audioObject = GameObject.Find("Sounds");
        SE = audioObject.gameObject.GetComponent<SoundEngine>();
        StartCoroutine(ChangeSize());
    }

    private void OnTriggerEnter(Collider other)
    {
        GF = other.gameObject.GetComponent<GrowFrog>();
        if (other.gameObject.CompareTag("Frog") && leafValue == 1 && GF.frogState == 3)
        {

            SE.PlayBreakLeaf();
            Destroy(gameObject);
        }
    }
    IEnumerator ChangeSize()
    {
        yield return new WaitForSeconds(1.5f);
        if (leafValue == 1)
        {
        gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if(leafValue==2)
        {
            gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else if (leafValue == 3)
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }



}
