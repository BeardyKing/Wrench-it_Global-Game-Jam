using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IfThisDiesYouLose : MonoBehaviour
{
    [SerializeField] int checkHowManyTurretsAreAlive = 0;
    [SerializeField] SpawnEnemy se;
    [SerializeField] Transform bigBoi;
    
    [SerializeField] private Image bar;
    [SerializeField] private Text text;
    [SerializeField] private Text restart;



    // Start is called before the first frame update
    void Start(){
        se = FindObjectOfType<SpawnEnemy>();
        rend = transform.GetComponent<Renderer>();

    }

    // Update is called once per frame
    public  float health = 3;
    float counter;
    private float timePassed;
    void Update(){
        
        if (health > 3){
            health = 3;
        }
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

        if (health <= 0){
            bar.color = Color.Lerp(bar.color, new Color(0, 0, 0, .35f), 2 * Time.deltaTime);
            text.color = Color.Lerp(text.color, new Color(1, 1, 1, 1f), 2 * Time.deltaTime);
            restart.color = Color.Lerp(restart.color, new Color(1, 1, 1, 1f), 2 * Time.deltaTime);
            text.text = "YOU LASTED : " + Math.Round(timePassed, 2);
            Time.timeScale = (Mathf.Lerp(Time.timeScale, 0.05f, 1 * Time.deltaTime));
            Debug.Log(Time.timeScale);
            if (Time.timeScale < 0.3f){
                Time.timeScale = 0;
            }
            if (Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene(0);
            }
        }
        else{
            timePassed += Time.deltaTime;
        }

        
        
        SetColour();
    }

    private Renderer rend;
    void SetColour() {
        Color c = new Color(Mathf.Abs(health - 1),health,0);
        rend.material.SetColor("_Color",c);
        if (health <= 0) {

        }
    }

    private void OnCollisionStay(Collision other){
        if (other.gameObject.tag == "Enemy"){
            health -= 0.01f;
        }
        
    }
}
