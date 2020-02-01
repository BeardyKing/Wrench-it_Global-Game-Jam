using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] [Range(0,1)] public float health;

    Renderer rend;
    // Start is called before the first frame update
    void Start() {

        rend = transform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
            SetColour();
        if (health <= 0) {
            Destroy(transform.gameObject);
        }
    }
    
    void SetColour() {
        Color c = new Color(Mathf.Abs(health - 1),health,0);
        rend.material.SetColor("_Color",c);
        
    }


    float counter;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Turret") {
            other.gameObject.GetComponent<GunController>().TakeDamage(0.001f);
            counter -= Time.deltaTime;
            if (counter <= 0) {
                if (other.gameObject.GetComponent<GunController>().health <= 0) {
                    SpawnEnemy temp = FindObjectOfType<SpawnEnemy>();
                    gameObject.GetComponent<MoveEnemy>().target = temp.target[Random.Range(0,temp.target.Count)];
                    counter = 5f;
                }
            }
        }
    }
}
