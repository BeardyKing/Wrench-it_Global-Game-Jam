using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfThisDiesYouLose : MonoBehaviour
{
    [SerializeField] int checkHowManyTurretsAreAlive = 0;
    [SerializeField] SpawnEnemy se;
    [SerializeField] Transform bigBoi;

    // Start is called before the first frame update
    void Start(){
        se = FindObjectOfType<SpawnEnemy>();
    }

    // Update is called once per frame
    float counter;
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0) {
            checkHowManyTurretsAreAlive = 0;
            counter = 2f;
            for (int i = 0;i < se.target.Count;i++) {
                if (se.target[i].GetComponentsInChildren<GunController>()[0].health <= 0) {
                    checkHowManyTurretsAreAlive++;
                }
                if (checkHowManyTurretsAreAlive == se.target.Count - 1) {
                    Debug.Log("HARD MODE!");
                    for (int j = 0;j < FindObjectsOfType<MoveEnemy>().Length;j++) {
                        FindObjectsOfType<MoveEnemy>()[j].target = transform;
                    }
                }
            }
        }
    }
}
