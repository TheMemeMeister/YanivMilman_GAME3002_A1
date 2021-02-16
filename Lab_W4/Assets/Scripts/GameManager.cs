using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    
    

    public Camera Camera2;
    public Camera Camera1;
    
    public GameObject mBall;
    public float timeScale = 1f;
    public float slowmoScale = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Camera1.enabled = true;
        Camera2.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.C) && Camera1.enabled == false)
        {
            Camera1.enabled = true;
            Camera2.enabled = false;
            //var mousePos = Camera1.ScreenToWorldPoint(Input.mousePosition);

            //// Calculate the vector between the mouse position and object
            ////fix this?
            //var vector = mBall.transform.position - mousePos;

            //// And then the distance
            //var distance = vector.magnitude;
        }
        if (Input.GetKeyDown(KeyCode.V) && Camera2.enabled == false)
        {
            Camera1.enabled = false;
            Camera2.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.V) && Camera2.enabled == false)
        {
            Camera1.enabled = false;
            Camera2.enabled = true;
        }
        //while (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Time.timeScale = timeScale * slowmoScale;
        //}
    }
    
}
