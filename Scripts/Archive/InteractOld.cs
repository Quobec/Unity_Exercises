using UnityEngine;

public class Interact : MonoBehaviour
{

    public MeshRenderer HandMR;
    public bool ShotOnOff;
    public Transform HandPos;
    public Transform cursor;
    RaycastHit hit;
    public Material Material;
    public float throwForce;

    void Update()
    {
        if(ShotOnOff){
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit , 2f)){
                    if(
                    hit.transform.gameObject.layer == 9 ||
                    hit.transform.gameObject.layer == 8 ||
                    hit.transform.gameObject.layer == 7
                    ){
                        HandMR.enabled = true;
                        HandPos.position = hit.point + transform.forward * -1 * .2f;
                        HandPos.LookAt(transform.position + transform.forward * hit.distance);
                    }
                if( hit.transform.gameObject.layer == 9 && Input.GetKey(KeyCode.Mouse0)){
                    // if object is grabbable 
                    // while LMB is clicked addForce to the obj towards the 3dCursor 
                    // located 2 units in front if the camera
                    hit.collider.gameObject.transform.position = cursor.position;
                    HandMR.enabled = false;
                    hit.collider.gameObject.transform.LookAt(transform.position);
                    if(Input.GetKeyDown(KeyCode.Mouse1)){
                        hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
                        ShotOnOff = true;
                    }
                } else if(hit.transform.gameObject.layer == 8 && Input.GetKeyDown(KeyCode.Mouse0)){
                    //if object is an item to pick up
                    //destroy obj and add item to inventory
                    Destroy(hit.collider.gameObject);
                    ShotOnOff = false;
                    //add item to inventory
                } else if(hit.transform.gameObject.layer == 7 && Input.GetKeyDown(KeyCode.Mouse0)){
                    //if object is interactable ex. button to open doors
                    hit.collider.GetComponent<Renderer>().material = Material;
                    ShotOnOff = false;
                    //open doors
                }
            } else {
                HandMR.enabled = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            ShotOnOff = true;
        }
    }
}