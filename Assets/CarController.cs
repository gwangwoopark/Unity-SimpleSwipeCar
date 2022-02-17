using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.speed <= 0.0f) {
            if(Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;
                this.startPos.x = 0;
                if(swipeLength < 0.0) return;
                this.speed = swipeLength / 1000.0f;
                this.GetComponent<AudioSource>().Play();
            }
        }
        this.transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;
        if(this.speed <= 0.001f) {
            this.speed = 0;
        }
    }
}
