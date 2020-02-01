using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] public GameObject prefab;
    [SerializeField] [Range(0,1)] public float health;
    [SerializeField] public Transform shootPos1;
    [SerializeField] public Transform shootPos2;

    int shootCounter = 0;
    float timeBetweenShots = .04f;
    float timer = 0;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        
        rend = transform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update(){
        SetColour();
        SetTarget();
        
    }

    Transform target;
    public void TakeDamage(float i) {
        health -= i;
        if (health <= 0 ) {
            health = 0;
        }
    }

    [SerializeField] GameObject temp;
    void SetTarget() {
        if (health > 0) {
            if (target != null) {
                transform.LookAt(target.position);
                timer -= Time.deltaTime;
            
                if (timer < 0) {
                    temp = Instantiate(prefab);
                    if (shootCounter == 0) {
                        temp.transform.position = shootPos1.position;
                        temp.GetComponent<Rigidbody>().AddForce((target.position - shootPos1.position) * 600);
                        shootCounter = 1;
                    }
                    else {
                        shootCounter = 0;
                        temp.transform.position = shootPos2.position;
                        temp.GetComponent<Rigidbody>().AddForce((target.position - shootPos2.position) * 600);
                    }
                    timer = timeBetweenShots;
                }
            }
        }
    }

    void SetColour() {
        Color c = new Color(Mathf.Abs(health - 1),health,0);
        rend.material.SetColor("_Color",c);
        if (health <= 0) {

        }
    }

    private void OnTriggerStay(Collider other) {
        if (health > 0) {
            if (other.gameObject.tag == "Enemy") {
                target = other.transform;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            target = null;
        }
    }


}
