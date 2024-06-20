using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    public GameObject[] upgrade;
    public GameObject levelUpMenu;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public void SpawnUpgradeChoices()
    {
        int upgradeLength = upgrade.Length;
        int first = SpawnFirstChoice(upgradeLength);
        int second = SpawnSecondChoice(upgradeLength, first);
        int third = SpawnThirdChoice(upgradeLength, first, second);

        Vector3 position1 = slot1.transform.position;
        Vector3 position2 = slot2.transform.position;
        Vector3 position3 = slot3.transform.position;

        GameObject button1 = Instantiate(upgrade[first], position1, Quaternion.identity);
        button1.transform.parent = levelUpMenu.transform;
        GameObject button2 = Instantiate(upgrade[second], position2, Quaternion.identity);
        button2.transform.parent = levelUpMenu.transform;
        GameObject button3 = Instantiate(upgrade[third], position3, Quaternion.identity);
    }

    public int SpawnFirstChoice(int upgradeLength)
    {
        int first = Random.Range(0, upgradeLength);
        return first;
    }

    public int SpawnSecondChoice(int upgradeLength, int first)
    {
        int second = Random.Range(0, upgradeLength);
        if (second != first)
        {
            return second;
        }
        else
        {
            return SpawnSecondChoice(upgradeLength, first);
        }
    } 

    public int SpawnThirdChoice(int upgradeLength, int first, int second)
    {
        int third = Random.Range(0, upgradeLength);

        if(third != first && third != second)
        {
            return third;
        }
        else
        {
            return SpawnThirdChoice(upgradeLength, first, second);
        }
    }
}
