using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Animator anim;
    [SerializeField] Transform cam;

    [SerializeField] Transform WrenchSpawnPos;
    [SerializeField] GameObject wrench;

    [SerializeField] List<GameObject> allWrenches;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    Vector3 inputDir;
    Vector3 dirToSend;

    bool readyToThrow;
    bool throwObj;
    bool onePass;
    void Update()
    {
        inputDir = Vector3.ProjectOnPlane(cam.forward,Vector3.up);
        dirToSend = new Vector3(inputDir.x,0,inputDir.z) * Input.GetAxis("Vertical");
        dirToSend += cam.right * Input.GetAxis("Horizontal");
        rb.velocity = dirToSend.normalized * 5;
        anim.SetFloat("speed",rb.velocity.magnitude);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("preThrow")) {
            if (Input.GetMouseButton(0)) {
                readyToThrow = true;
                throwObj = false;
            }
            else {
                readyToThrow = false;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            throwObj = true;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("throw")) {
                onePass = true;
            }
            
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("throw") && onePass == true) {
            onePass = false;
            allWrenches.Add(Instantiate(wrench));
            allWrenches[allWrenches.Count - 1].transform.position = WrenchSpawnPos.transform.position;
            allWrenches[allWrenches.Count - 1].GetComponent<Rigidbody>().AddForce(cam.forward * 900);
            allWrenches[allWrenches.Count - 1].GetComponent<Rigidbody>().AddTorque(-cam.forward * 900000);
        }


        anim.SetBool("readyToThrow",readyToThrow);
        anim.SetBool("throwObj",throwObj);
    }
}
