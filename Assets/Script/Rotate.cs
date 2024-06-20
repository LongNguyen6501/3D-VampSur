using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform player;
    public Transform middlePoint;
    public float rotateSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //void Update()
    //{
    //    transform.RotateAround(middlePoint.position, Vector3.up, rotateSpeed*Time.deltaTime);
    //    float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
    //    if(distanceFromPlayer > 20 )
    //    {
    //        transform.position.y = 0;
    //    }
    //}
}
