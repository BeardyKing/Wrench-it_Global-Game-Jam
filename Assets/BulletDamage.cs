using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<DealDamage>().health -= .01f;
            Destroy(transform.gameObject);
        }
        //transform.gameObject.GetComponent<SphereCollider>().isTrigger = false;

    }
}
