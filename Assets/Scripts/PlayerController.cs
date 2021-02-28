using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float leftLimit = -2.65f;
    private float rightLimit = 4.65f;
    private readonly float speed = 0.01f;
    private bool move = false;
    private Vector3 target;
    private Vector2 startPos;
    public int score;
    public Text textScore;
    void Start() {
        score = 0;
    }

    void Update() {
        textScore.text = "Score: " + score;
    }
    private void FixedUpdate() {
       
        if(transform.position.x > rightLimit){
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < leftLimit){
                transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
        }
        if (Input.touchCount > 0) {
            var touch = Input.GetTouch(0);
 
            switch (touch.phase)  {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
 
                case TouchPhase.Moved:
                    var dir = touch.position - startPos;
                    
                    var pos = transform.position + new Vector3(dir.x, transform.position.y, transform.position.y);
                    transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);
                    if(dir.x > rightLimit){
                        dir.x = rightLimit;
                    }
                    else if (dir.x < leftLimit){
                        dir.x = leftLimit;
                    }
                    break;
            }
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
    }
}
