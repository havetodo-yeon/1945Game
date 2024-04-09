using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image startImage;
    private void Start()
    {
        //startImage = GetComponent<Image>();
        StartCoroutine(GameInsert());
    }

    IEnumerator GameInsert()
    {
        while (true)
        {
            startImage.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(1f);
            startImage.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(1f);
        }
    }


}
