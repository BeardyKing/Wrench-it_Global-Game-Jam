using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour{
    private CameraController cc;
    [SerializeField] private Image img;
    [SerializeField] private Text txt;
    
    // Start is called before the first frame update
    void Awake(){
        
        Time.timeScale = 0;
        cc = FindObjectOfType<CameraController>();
    }

    private bool once = true;

    // Update is called once per frame
    private float timer = 5f;
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0)){
            if (once){
                Time.timeScale = 1;
                once = false;
                
            }
        }

        if (timer > 3.5f){
            cc.rotationX = 18.17f;
            cc.rotationY = 32.82f;
            cc.sensitivityX = .1f;
            cc.sensitivityY = .1f;

            cc.updateOverride = false;
        }
        else{
            cc.sensitivityX = 1;
            cc.sensitivityY = 1;
        }

        if (!once){
            timer -= Time.deltaTime;
                img.color = Color.Lerp(img.color, new Color(0, 0, 0, 0), 2 * Time.deltaTime);
                txt.color = Color.Lerp(txt.color, new Color(1, 1, 1, 0), 2 * Time.deltaTime);
            if (timer <= 0){
            }
        }
    }
}
