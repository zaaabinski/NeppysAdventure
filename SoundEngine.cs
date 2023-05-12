using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEngine : MonoBehaviour
{
    //charing
    [SerializeField] AudioSource charginSound;
    //jumps
    [SerializeField] AudioSource smallJump;
    [SerializeField] AudioSource mediumJump;
    [SerializeField] AudioSource bigJump;
    //walks
    [SerializeField] AudioSource smallWalk;
    [SerializeField] AudioSource mediumWalk;
    [SerializeField] AudioSource bigWalk;

    //lands 
    [SerializeField] AudioSource smallLand;
    [SerializeField] AudioSource mediumLand;
    [SerializeField] AudioSource bigLand;
    //grow
    [SerializeField] AudioSource growFrog;
    [SerializeField] AudioSource eatFly;
    //leaf
    [SerializeField] AudioSource placeLeaf;
    [SerializeField] AudioSource breakLeaf;
    private GrowFrog GF;
    [SerializeField] GameObject frogObj;
    private void Start()
    {
        GF = frogObj.gameObject.GetComponent<GrowFrog>();
    }
   /* private void Update()
    {
        MoveSounds();
    }*/
    void MoveSounds()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)  || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (GF.frogState == 1)
            {
                smallWalk.enabled = true;
            }
            if (GF.frogState == 2)
            {
                mediumWalk.enabled = true;
            }
            if (GF.frogState == 3)
            {
                bigWalk.enabled = true;
            }
        }
        else
        {
            smallWalk.enabled = false;
            mediumWalk.enabled = false;
            bigWalk.enabled = false;
        }
    }

    public void WinGameSounds()
    {

    }


    //charg
    public void PlayCharge()
    {
        charginSound.Play();
    }
    //jumps
    public void PlaySmallJump()
    {
        smallJump.Play();
    }
    public void PlayMidJump()
    {
        mediumJump.Play();
    }
    public void PlayBigJump()
    {
        bigJump.Play();
    }

    //walks
    public void PlaySmallWalk ()
    {
        smallWalk.Play();
    }
    public void PlayMidWalk()
    {
        mediumWalk.Play();
    }
    public void PlayBigWalk()
    {
        bigWalk.Play();
    }

    //lands
    public void PlaySmallLand()
    {
        smallLand.Play();
    }
    public void PlayMidLand()
    {
        mediumLand.Play();
    }
    public void PlayBigLand()
    {
        bigLand.Play();
    }
    //growing
    public void PlayGrowFrog()
    {
        growFrog.Play();
    }
    public void PlayEatFly()
    {
        eatFly.Play();
    }
    //leafs
    public void PlayPlaceLeaf()
    {
        placeLeaf.Play();
    }
    public void PlayBreakLeaf()
    {
        breakLeaf.Play();
    }
    
   
}
