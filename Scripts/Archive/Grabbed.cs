using UnityEngine;

public class Grabbed : MonoBehaviour
{
    private Rigidbody crateRigidbody;
    public Transform CameraTM;
    public Transform cursor;
    public Material materialNormal;
    public Material materialTransparent;
    public float force;
    public float throwForce;
    public float dropDistance;
    public float grabDrag;
    public float freeDrag;

    void DropObject(){
        enabled = false;
        crateRigidbody.drag = freeDrag;
        crateRigidbody.useGravity = true;
        gameObject.layer = 9;
    }

    void OnEnable(){
        gameObject.GetComponent<MeshRenderer>().material = materialTransparent;
        crateRigidbody = gameObject.GetComponent<Rigidbody>();
        crateRigidbody.drag = grabDrag;
        crateRigidbody.useGravity = false;
    }

    void Update()
    {
        float distanceCursorToTarget = Vector3.Distance(cursor.position,transform.position);
        crateRigidbody.AddForce((cursor.position - transform.position) * (Mathf.Pow(distanceCursorToTarget,1.4f)*force), ForceMode.Force);

        if(Input.GetKeyUp(KeyCode.Mouse0) || distanceCursorToTarget > dropDistance){
            DropObject();
            crateRigidbody.velocity = crateRigidbody.velocity.normalized;
            gameObject.GetComponent<MeshRenderer>().material = materialNormal;
        }
        
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            DropObject();
            crateRigidbody.velocity = new Vector3(0,0,0);
            crateRigidbody.AddForce(CameraTM.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
            gameObject.GetComponent<MeshRenderer>().material = materialNormal;
        }
    }
}