using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(BeingFlicker());
    }

    IEnumerator BeingFlicker()
    {
        Debug.Log("Start");
        float timeSetting = 0;
        SpriteRenderer objectColor = gameObject.GetComponent<SpriteRenderer>();
        while (timeSetting < 1.0f)
        {
            objectColor.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.1f);
            objectColor.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
            timeSetting += 0.1f;
        }
        Debug.Log("End");
    }

}
