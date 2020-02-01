using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] public Transform target;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        rb.AddForce((target.position - transform.position).normalized * (400 * Time.deltaTime));
    }
}
