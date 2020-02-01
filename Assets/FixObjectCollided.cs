using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixObjectCollided : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<DealDamage>().health += .7f;
            Destroy(transform.gameObject);
        }
        if (other.gameObject.tag == "Turret") {
            other.gameObject.GetComponent<GunController>().health += 1.2f;
            Destroy(transform.gameObject);
        }
        if (other.gameObject.tag == "Tower") {
            other.gameObject.GetComponent<IfThisDiesYouLose>().health += .6f;
            Destroy(transform.gameObject);
        }
    }
}
