using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToLeaf : MonoBehaviour
{
    private DestroyOnFrog DOF;
    private GrowFrog GF;
    private FrogMovement FM;
    [SerializeField] GameObject leafOb;
    public bool leafing = false;
    //public int frogLives;
    private UIManagment UIM;
    [SerializeField] GameObject uiMan;
    [SerializeField] TriggersAndBools TAB;
    [SerializeField] GameObject audioObject;
    private SoundEngine SE;
    bool canLeaf = true;
    [SerializeField] GameObject blackBack;
    private void Start()
    {
        UIM = uiMan.gameObject.GetComponent<UIManagment>();
        GF = gameObject.GetComponent<GrowFrog>();
        FM = gameObject.GetComponent<FrogMovement>();
        SE = audioObject.gameObject.GetComponent<SoundEngine>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("f") && !UIM.Paused && canLeaf)
        {
            StartCoroutine(TurnLeaf());
        }
    }
    
    IEnumerator TurnLeaf()
    {
        if ((GF.frogState == 1 && TAB.SmallBool) || (GF.frogState == 2 && TAB.MediumBool) || (GF.frogState == 3 && TAB.BigBool))
        {
            leafing = true;
            Vector3 savedPos;
            savedPos = gameObject.transform.position;
            SE.PlayPlaceLeaf();
            //play animation black out screen
            blackBack.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            transform.localScale = new Vector3(1f, 1f, 1f);
            //place where frog gets placed after turning to leaf
            transform.position = new Vector3(0f, 1f, -12f);
            GameObject leafPref;
            leafPref = Instantiate(leafOb, savedPos, Quaternion.identity);
            DOF = leafPref.GetComponent<DestroyOnFrog>();


            DOF.leafValue = GF.frogState;
            GF.frogState = 1;
            GF.flyEat = 0;
            //frogLives -= 1;
            GF.frogJump = 1;
            GF.frogSpeed = 5;
            GF.flysLv = 2;
            FM.speed = 5;

            yield return new WaitForSeconds(1);
            leafing = false;
            blackBack.SetActive(false);
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("JumpRoom"))
        {
            canLeaf = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("JumpRoom"))
        {
            canLeaf = false;
        }
    }
}
