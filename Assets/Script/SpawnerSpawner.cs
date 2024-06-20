using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject bullet;
    public GameObject weapon;
    public int mrLv;
    void Start()
    {
        float x = 450f;
        float z = 450f;
        while (x > -500f)
        {
            while (z > -500f)
            {
                Instantiate(spawner, new Vector3 (x, 0, z), Quaternion.identity);
                z = z-50;
            }
            x = x-50;
            z = 500f;
        }
        ResetLevel();
    }

    public void ResetLevel()
    {
        weapon.GetComponent<Weapon>().ResetLevel();
        bullet.GetComponent<Bullet>().ResetLevel();
        mrLv = 0;
    }

    public void IncreaseMRLv()
    {
        if(mrLv < 6)
        {
            mrLv++;
        }
    }
}
