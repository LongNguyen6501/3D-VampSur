using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public float maxHP = 100f;
    public float playerHP = 100f;
    public float XP = 0;
    public int level = 1;
    public GameObject globalReferences;
    
    public float[] XPReq;
    public void TakeDamage(float damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainScreen");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            print(playerHP);
        }
    }
    public void AddXP(float XPGained)
    {
        if(level < 36)
        {
            XP += XPGained;
            int XPReqCurr = level - 1;
            if (XP > XPReq[XPReqCurr])
            {
                LevelUp();
            }
        }
    }

    public void LevelUp()
    {
        playerHP = maxHP;
        level += 1;
        globalReferences.GetComponent<LevelUpMenu>().LevelUp();
        print("you are now LV " + level);
        XP = 0;
    }
}
