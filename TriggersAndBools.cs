using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggersAndBools : MonoBehaviour
{
    public bool SmallBool = false;
    public bool MediumBool = false;
    public bool BigBool = false;
    [SerializeField] GameObject bridgeOne;
    [SerializeField] GameObject bridgeTwo;
    [SerializeField] GameObject bridgeThree;
    [SerializeField] Sprite tadpolImage;
    [SerializeField] Sprite smallFrogImage;
    [SerializeField] Sprite mediumFrogImage;
    [SerializeField] Sprite bigFrogImage;
    [SerializeField] Image spriteEdit;

    private void Update()
    {
        if(SmallBool)
        {
            spriteEdit.sprite = smallFrogImage;
            bridgeOne.SetActive(false);
            bridgeTwo.SetActive(true);
        }
         if(SmallBool && MediumBool)
        {
            spriteEdit.sprite = mediumFrogImage;
            bridgeTwo.SetActive(false);
            bridgeThree.SetActive(true);
        }
         if(SmallBool && MediumBool && BigBool)
        {
            spriteEdit.sprite = bigFrogImage;
            bridgeThree.SetActive(false);
        }
        if (!SmallBool && !MediumBool && !BigBool)
        {
            spriteEdit.sprite = tadpolImage;

        }
    }
}
