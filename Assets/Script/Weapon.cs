using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera playerCamera;

    public int atkSpdLv = 0;

    //Shooting
    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 0.1f;

    //Burst
    public int bulletsPerBurst = 3;
    public int burstBulletLeft;

    //Spread
    public float spreadIntensity;

    //Bullet
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 30f;

    public enum ShootingMode
    {
        Single,
        Burst,
        Auto
    }

    public ShootingMode currentShootingMode;

    private void Awake()
    {
        readyToShoot = true;
        burstBulletLeft = bulletsPerBurst;
    }


    void Update()
    {
        if (!PauseMenu.isPause)
        {
            if (currentShootingMode == ShootingMode.Auto)
            {
                //Holding down left key
                isShooting = Input.GetKey(KeyCode.Mouse0);

            }
            else if (currentShootingMode == ShootingMode.Single || currentShootingMode == ShootingMode.Burst)
            {
                //click left key
                isShooting = Input.GetKeyDown(KeyCode.Mouse0);
            }

            if (isShooting && readyToShoot)
            {
                burstBulletLeft = bulletsPerBurst;
                FireWeapon();
            }
        }
    }

    private void FireWeapon()
    {
        readyToShoot = false;

        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;
        //Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        //pointing at shooting direction
        bullet.transform.forward = shootingDirection;

        //Shoot bullet
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward.normalized * bulletVelocity, ForceMode.Impulse);

        //Destroy bullet
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

        //checking if done shooting
        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }

        //Burst mode
        if(currentShootingMode == ShootingMode.Burst && burstBulletLeft > 1)
        {
            burstBulletLeft--;
            Invoke("FireWeapon", shootingDelay);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
    }
    public Vector3 CalculateDirectionAndSpread()
    {
        //cast ray from middle of screen
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit) && hit.transform.name != "Player")
        {
            targetPoint = hit.point;
        }

        else
        {
            //shooting at the air
            targetPoint = ray.GetPoint(10000);
        }

        Vector3 direction = targetPoint - bulletSpawn.transform.position;

        float x = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);

        //Returning shooting direction and spread
        return direction + new Vector3(x, y, 0);
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    public void AtkSpdUp()
    {
        if(atkSpdLv < 5)
        {
            shootingDelay = shootingDelay / 2;
            atkSpdLv += 1;
        }
    }

    public void ResetLevel()
    {
        atkSpdLv = 0;
    }

}
