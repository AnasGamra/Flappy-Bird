using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Camerafollow : MonoBehaviour { 

    public Transform birdTransform;
    Vector3 range;

    void Awake ()
    {
        range = transform.position - birdTransform.position;
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(range.x + birdTransform.position.x, transform.position.y, -10);
    }
}
