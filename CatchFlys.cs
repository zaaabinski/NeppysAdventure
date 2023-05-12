using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFlys : MonoBehaviour
{
    bool canShot = true;
    [SerializeField] LayerMask flyMask;
    private GrowFrog GF;
    // Update is called once per frame
    private UIManagment UIM;
    [SerializeField] GameObject uiMan;
    [SerializeField] GameObject audioObject;
    private SoundEngine SE;

    private void Start()
    {
        GF = gameObject.GetComponent<GrowFrog>();
        UIM = uiMan.gameObject.GetComponent<UIManagment>();
        SE = audioObject.gameObject.GetComponent<SoundEngine>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShot && !UIM.Paused)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        canShot = false;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(rayOrigin, out hitInfo,20f))
        {
            if(hitInfo.transform.gameObject.CompareTag("Fly"))
            {
            GF.flyEat += 1;
            float one, two, three,rot;
            one = Random.Range(1, 15);
            two = Random.Range(2, 5);
            three = Random.Range(1, 15);
             rot = Random.Range(1f, 180f);
            hitInfo.transform.gameObject.transform.position = new Vector3(one,two,three);
                hitInfo.transform.gameObject.transform.Rotate(0, rot, 0);
                SE.PlayEatFly();

            }
        }
        else
        {
        }
        yield return new WaitForSeconds(1);
        canShot = true;
    }
}
