using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoubleJump : MonoBehaviour
{
    //CharacterJumpingComponents
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Movement tower;
    public Transform leftSideCheck;
    public Transform rightSideCheck;

    //JumpingVariables
    private float gravity = -10f;
    private float groundDistance = 0.1f;
    private float jumpHeight = 3.3f;
    private bool isGrounded;
    private Vector3 velocity;

    //DebugVariables
    private float jumpDebugDelayTime = 0.5f;
    private int consoleDebugJumpCounter;

    void Start()
    {
        //Does Nothing For Now
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //StartCoroutine(JumpDebug());
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        LockPosition();
    }

    /*private IEnumerator JumpDebug()
    {
        yield return new WaitForSeconds(jumpDebugDelayTime);
        consoleDebugJumpCounter++;
        
        Debug.Log("                                                            " + "||" + consoleDebugJumpCounter + "====================" + consoleDebugJumpCounter + "=====================" + consoleDebugJumpCounter + "||");
        Debug.Log("                                                                                          " + "Jumped (" + velocity.y + ") Units High");
        Debug.Log("                                                                                          " + "Is On The Ground: " + "|====" + isGrounded + "====|");
        Debug.Log("                                                            " + "||" + consoleDebugJumpCounter + "====================" + consoleDebugJumpCounter + "=====================" + consoleDebugJumpCounter + "||");
        Debug.Log("");
    } */
    private void LockPosition()
    {
        if ((gameObject.transform.position.x != 0) && (gameObject.transform.position.z != 0))
        {
            gameObject.transform.position = new Vector3(0f, gameObject.transform.position.y, 63.9f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            print("NO ELO");
            tower.direction = 0f;
        }
    }       
}