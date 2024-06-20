using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject levelUpMenu;
    public GameObject player;
    public GameObject weapon;
    public GameObject bullet;
    public GameObject currMR;
    public GameObject[] mr;
    public int mrLv;

    public static bool levelingUp = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        levelUpMenu = GameObject.FindGameObjectWithTag("LevelUpMenu");
    }

    void Update()
    {
    }

    public void LevelUp()
    {
        levelUpMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        levelingUp = true;
        levelUpMenu.GetComponent<UpgradeSpawner>().SpawnUpgradeChoices();
    }

    public void AtkSpdUp()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        levelUpMenu = GameObject.FindGameObjectWithTag("LevelUpMenu");
        weapon.GetComponent<Weapon>().AtkSpdUp();
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        levelUpMenu.SetActive(false);
        levelingUp = false;
    }

    public void DmgUp()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        levelUpMenu = GameObject.FindGameObjectWithTag("LevelUpMenu");
        bullet.GetComponent<Bullet>().DmgUp();
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        levelUpMenu.SetActive(false);
        levelingUp = false;
    }

    //public void MeteorRing()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    weapon = GameObject.FindGameObjectWithTag("Weapon");
    //    levelUpMenu = GameObject.FindGameObjectWithTag("LevelUpMenu");
    //    mrLv = 
        
    //    Time.timeScale = 1f;
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //    levelUpMenu.SetActive(false);
    //    levelingUp = false;
    //}
}
