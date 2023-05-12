using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogMovement : MonoBehaviour
{

    float horizontal, vertical;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;
    public float speed = 10f;
    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    public float gravity = -9.81f;
    //public float jump = 3f;
    [SerializeField] float chargin = 0;
    private GrowFrog GF;
    private TurnToLeaf TTL;
    [SerializeField] Slider sd;
    float jumpForce;
    [SerializeField] GameObject audioObject;
    private SoundEngine SE;
    bool groundedSoundBool=false;
    [SerializeField] Animator anim;
    [SerializeField] UIManagment UIM;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GF = gameObject.GetComponent<GrowFrog>();
        TTL = gameObject.GetComponent<TurnToLeaf>();
        sd.maxValue = 100;
        SE = audioObject.gameObject.GetComponent<SoundEngine>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!TTL.leafing && !UIM.Paused)
        {
        Move();
        ChargeJump();
        }


    }

    void ChargeJump()
    {
        if(Input.GetKeyDown("space"))
        {
            SE.PlayCharge();
            anim.SetTrigger("Charge");
        }
        if (Input.GetKey("space") && isGrounded)
        {
            chargin += 80 * Time.deltaTime;
            sd.value = chargin;
            speed = 1;
        }
        if (Input.GetKeyUp("space"))
        {
            
            
            if (GF.frogState==1)
            {
            SE.PlaySmallJump();

            }
            else if (GF.frogState == 2)
            {
                SE.PlayMidJump();
            }
            else if (GF.frogState == 3)
            {
                SE.PlayBigJump();
            }
            if (chargin<75)
            {
                //jump at 50%height
                jumpForce=GF.frogJump*chargin/100;
                anim.SetTrigger("Relese");
            }
            else if(chargin>=75&&chargin<=90)
            {
                //jump at 100%
                jumpForce = GF.frogJump;
                anim.SetTrigger("Relese");
            }
            else
            {
                anim.SetTrigger("Relese");
                //jumpt at 50%
                jumpForce = GF.frogJump * chargin *0.25f / 100;
            }
            sd.value = Mathf.Lerp(GF.frogJump, 0, 50f);
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            chargin = 0;
            jumpForce = 0;
            speed = GF.frogSpeed;
        }
    }
    void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction == Vector3.zero)
        {
            anim.SetFloat("Speed", 0);
            if(GF.frogState==1)
            {
            anim.speed = 1.5f;
            }
            else if(GF.frogState==2)
            {
                anim.speed = 1.25f;
            }
            else
            {
                anim.speed = 1;
            }
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) 
            || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetFloat("Speed", 2);
        }
        if (direction.magnitude >= 0.1f)
        {
            //rotation
            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float Angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angel, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded&&!groundedSoundBool)
        {
            StartCoroutine(GroundedSound());
        }
        if(!isGrounded)
        {
            groundedSoundBool = false;
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
           
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator GroundedSound()
    {
         groundedSoundBool = true;
        if (GF.frogState == 1)
        {
            SE.PlaySmallLand();
        }
        else if (GF.frogState == 2)
        {
            SE.PlayMidLand();
        }
        else if (GF.frogState == 3)
        {
            SE.PlayBigLand();
        }
        yield return new WaitForSeconds(1);
    }


}
