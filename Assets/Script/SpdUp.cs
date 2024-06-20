using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdUp : MonoBehaviour
{
    public GameObject globalReferences;
    void Start()
    {
        globalReferences = GameObject.FindGameObjectWithTag("GlobalRef");
    }

    void Update()
    {
        
    }
}
