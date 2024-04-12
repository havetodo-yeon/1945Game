using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BombAirplan : MonoBehaviour
{
    public int Speed;
    public GameObject[] bombPos;
    public GameObject bombPrefab;
    int bombCount = 1;


    private void Start()
    {
        StartCoroutine(Bombing());
    }

    private void Update()
    {
        transform.Translate(Vector2.up* Speed * Time.deltaTime);
    }

    IEnumerator Bombing()
    {
        while (bombPos[bombCount].transform.position.y < 3.5)
        {
            yield return new WaitForSeconds(0.9f);
            if(bombCount == 1)
            {
                bombCount--;
            }
            else
            {
                bombCount++;
            }
            Instantiate(bombPrefab, bombPos[bombCount].transform.position, Quaternion.identity);
        }
    }

}
