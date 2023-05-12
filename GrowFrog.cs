using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrowFrog : MonoBehaviour
{
    public int flyEat;
    public int frogState = 1;
    [SerializeField] FrogMovement FM;
    public int frogSpeed = 4;
    public int frogJump = 4;
    private UIManagment UIM;
    [SerializeField] SoundEngine SE;
    [SerializeField] GameObject uiMan;
    [SerializeField] TriggersAndBools TAB;
    [SerializeField] AudioSource smaAS;
    [SerializeField] AudioSource medAS;
    [SerializeField] AudioSource bigAS;
    [SerializeField] AudioSource gameWinSound;
    [SerializeField] GameObject gameEnd;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Cam;
    [SerializeField] Animator anim;
    public bool gameWon = false;
    public int flysLv = 2;
    [SerializeField] TextMeshProUGUI flyText;

    private void Start()
    {
        UIM = uiMan.gameObject.GetComponent<UIManagment>();
        FM = gameObject.GetComponent<FrogMovement>();
        frogSpeed = 5;
        frogJump = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown("g") && !UIM.Paused)
        {
            StartCoroutine(GrowSize());
        }
        if(frogState==1)
        {
            StartCoroutine(StartFade(medAS, 1, 0));
            StartCoroutine(StartFade(bigAS, 1, 0));
        }
        flyText.text = flyEat + "/" + flysLv;
    }
    public IEnumerator WinGameSounds()
    {
        anim.SetFloat("Speed", 0);
        gameWon = true;
        Cursor.lockState = CursorLockMode.None;
        Cam.SetActive(false);
        gameEnd.SetActive(true);
        UI.SetActive(false);
        gameWinSound.Play();
        StartCoroutine(StartFade(gameWinSound, 1, 1));
        StartCoroutine(StartFade(smaAS, 1, 0));
        StartCoroutine(StartFade(medAS, 1, 0));
        StartCoroutine(StartFade(bigAS, 1, 0));
        yield return new WaitForSeconds(10);
        StartCoroutine(StartFade(smaAS, 1, 1));
        StartCoroutine(StartFade(medAS, 1, 1));
        StartCoroutine(StartFade(bigAS, 1, 1));
        

    }
    IEnumerator GrowSize()
    {
        if (flyEat >= flysLv && frogState == 1 && TAB.SmallBool)
        {
            Debug.Log("grow");
            flyEat = 0;
            frogState = 2;
            transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
            FM.speed = 3;
            frogSpeed = 3;
            frogJump = 3;
            StartCoroutine(StartFade(medAS, 1, 1));
            SE.PlayGrowFrog();
            flysLv = 4;
        }
        else if (flyEat >= flysLv && frogState == 2 && TAB.MediumBool)
        {
            Debug.Log("grow");
            flyEat = 0;
            frogState = 3;
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            FM.speed = 2;
            frogSpeed = 2;
            frogJump = 5;
            SE.PlayGrowFrog();
            StartCoroutine(StartFade(bigAS, 1, 1));
        }
        else if (frogState == 3)
        {
            Debug.Log("You too big");
        }
        else
        {
            Debug.Log("Not enough flys");
        }
        yield return new WaitForSeconds(1);
    }
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
