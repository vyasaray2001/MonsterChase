using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    private Transform player;
    private Vector3 tempCam;
    [SerializeField]private float min=-47.17f,max=47.703f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(GameMangerScript.instance.CharIdex);
       player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!player) return; 
        
        tempCam = transform.position;
        if (player.position.x < min)
        {
            tempCam.x = min;
        }
        else
            tempCam.x=player.position.x;
        if (player.position.x > max)
        {
            tempCam.x = max;
        }
        else
            tempCam.y=player.position.y;
        transform.position = tempCam;
       // transform.position= tempCam;
    }
}
