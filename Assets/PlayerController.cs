  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController2D controller;
    private Vector3 initialPosition = new Vector3(0.0f,0.0f,0.0f);
    public bool jump = false;
    private bool crouch = false;
    public float horizontalMove = 0.0f;
    private float runSpeed =40.0f;
    private Animator animator;
    private GameObject m_Key;
    private bool haskey=false;
    private Vector3 Keyposition = new Vector3(7.0f, 0.0f, 0.0f); 
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        haskey = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            //animator.SetBool("isJumping", true);

        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        horizontalMove = Input.GetAxis("Horizontal")*runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        animator.SetBool("isCrouching", crouch);
        animator.SetBool("isGrounded", controller.m_Grounded);
        animator.SetFloat("velocityY", controller.m_Rigidbody2D.velocity.y);

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Key")
        {
            haskey = true;
            m_Key = col.gameObject;
            m_Key.transform.position = transform.position;
            m_Key.transform.parent = transform;
        }

        if(col.gameObject.tag =="Door" && haskey)
        {
            Destroy(col.gameObject);
            Destroy(m_Key);
            haskey = false;
        }
        if (col.gameObject.tag == "End")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
