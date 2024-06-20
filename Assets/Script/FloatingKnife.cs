using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingKnife : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            collision.gameObject.GetComponent<zombie>().TakeDamage(damage);
        }
    }
}
