using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] public List<Transform> target;
    [SerializeField] GameObject prefab;

    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        timePassed -= Time.deltaTime;
        if (timePassed < 0) {
            timePassed = Random.Range(2,30);
            GameObject temp = Instantiate(prefab);
            temp.transform.position = transform.position;
            temp.GetComponent<MoveEnemy>().target = target[Random.Range(0,target.Count)];
        }
    }
}
