using UnityEngine;

public class RBPlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    float horInput;
    float verInput;
    public float groundDrag;
    public LayerMask Ground;
    bool grounded;

    public float playerSpeed;
    public float jumpForce;
    public float crouchSpeedModifier;

    void OnCollisionStay(Collision collisionInfo)
    {
        if( collisionInfo.gameObject.layer == 6){
            grounded = true;
        }
    }
    void OnCollisionExit()
    {
        grounded = false;
    }

    void Update()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Space) && grounded){
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
        if(grounded){
            playerRigidbody.drag = groundDrag;
        } else { 
            playerRigidbody.drag = 0;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            transform.localScale = new Vector3(1, .5f, 1);
            playerSpeed = playerSpeed/crouchSpeedModifier;
            playerRigidbody.AddForce(transform.up * -10, ForceMode.Impulse);
        }
        if(Input.GetKeyUp(KeyCode.LeftControl)){
            transform.localScale = new Vector3(1, 1, 1);
            playerSpeed = playerSpeed*crouchSpeedModifier;
        }
    }

    void FixedUpdate(){
        if(grounded){
            var Move = new Vector3();
            Move += transform.TransformDirection(Vector3.forward) * verInput + transform.TransformDirection(Vector3.right) * horInput;
            playerRigidbody.AddForce(Move.normalized * playerSpeed, ForceMode.Force);
        }
    }
}