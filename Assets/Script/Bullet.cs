using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    int bulletDamage;
    public int[] damageByLevel;
    public int bulletLevel;

    private void Update()
    {
        bulletDamage = damageByLevel[bulletLevel];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            CreateBulletImpactEffect(collision);

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            CreateBulletImpactEffect(collision);

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            CreateBulletImpactEffect(collision);

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Zombie"))
        {
            CreateBulletImpactEffect(collision);

            collision.gameObject.GetComponent<zombie>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }

    }

    void CreateBulletImpactEffect(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
            );
        hole.transform.SetParent(collision.gameObject.transform);
    }

    public void DmgUp()
    {
        if(bulletLevel < 5)
        {
            bulletLevel += 1;
        }
    }

    public void ResetLevel()
    {
        bulletLevel = 0;
    }

}
