using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject potion;
    //Cam movement
    [SerializeField] private Transform _eyes;
    [SerializeField] private float _sensitivity;

    [SerializeField] private float _camLimitMin;

    [SerializeField] private float _camLimitMax;

    private float _camAngle = 0.0f;


    //Movement
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _sprintingSpeed;
    [SerializeField] private float _crouchingSpeed;
    private Rigidbody _rb;

    //Sprinting
    [SerializeField] private KeyCode _sprintingKey;

    //Jump
    [SerializeField] private float _jumpForce;
    [SerializeField] private KeyCode _jumpKey;

    //Crouch
    [SerializeField] private KeyCode _crouchKey;

    //Peek
    [SerializeField] private KeyCode _leftSidePeekKey;
    [SerializeField] private KeyCode _rightSidePeekKey;

   



    
    public Movementstates state;
    
    public enum Movementstates
    {
        walking,
        sprinting,
        crouching,
        peeking,
        air
    }

    private void StateHandler()
    {
       if (Input.GetKey(_leftSidePeekKey) || Input.GetKey(_rightSidePeekKey))
       {           state = Movementstates.peeking;
            SidePeek();
       }
        else if (IsGrounded() && Input.GetKey(_crouchKey))
        {

            state = Movementstates.crouching;
            _playerSpeed = _crouchingSpeed;
        }
        else if (IsGrounded() && Input.GetKey(_sprintingKey))
        {
         
            state = Movementstates.sprinting;
            _playerSpeed = _sprintingSpeed;
        }
       else if (IsGrounded())
       {
            state = Movementstates.walking;
            _playerSpeed = _walkingSpeed;
       }
       else
       {
            state = Movementstates.air;
       }
    }

     void Start()
     {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


     }

   
     private void Update()
     {
        RotateEyes();
        RotateBody();
        

        StateHandler();
        if (Input.GetKeyDown(_jumpKey))
        {
            TryJump();
        }
        if (Input.GetKey(_crouchKey))
        {
            Crouch();
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

       
     }  

    private void FixedUpdate()
    {
        Move();
        
    }
    private void RotateEyes()
    {
        float yMouse = Input.GetAxisRaw("Mouse Y") * _sensitivity * Time.deltaTime;
        _camAngle -= yMouse;
        _camAngle = Mathf.Clamp(_camAngle, _camLimitMin, _camLimitMax);
        _eyes.localRotation = Quaternion.Euler(_camAngle, 0, 0);
    }


    private void RotateBody()
    {
        float xMouse = Input.GetAxisRaw("Mouse X") * _sensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * xMouse);
    }

    

    private void Move()
    {
        if (IsGrounded())
        {
            float xDir = Input.GetAxis("Horizontal");
            float zDir = Input.GetAxis("Vertical");

            Vector3 dir = transform.right * xDir + transform.forward * zDir;
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0) + dir.normalized * _playerSpeed;
        }
        else
        {

        }
        


    }
    private void Crouch()
    {
        gameObject.transform.localScale = new Vector3(1f, 0.8f, 1f);
    }



    private void SidePeek()
    {
        
        if (Input.GetKey(_leftSidePeekKey))
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(0, 0, 10), 1f * Time.deltaTime);
        }
        
       

        if (Input.GetKeyUp(_rightSidePeekKey))
        {
            Instantiate(potion, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        }
        
    }
    private void TryJump()
    {
        if (IsGrounded())
        {
            Jump(_jumpForce);
        }
    }

    private void Jump(float jumpForce)
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
   
    private bool IsGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, -transform.up, out hit, 2f);
    }



   
}
