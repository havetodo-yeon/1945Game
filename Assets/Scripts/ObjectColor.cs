using System.Collections;
using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    public static ObjectColor Instance;

    private void Awake()
    {
        if (Instance == null)    // null 체크
        {
            Instance = this;    // 자기 자신 인스턴스해서 저장
        }
    }

    public void GetHurt(GameObject gameObject)
    {
        StartCoroutine(BeingRed(gameObject));
    }
    IEnumerator BeingRed(GameObject gameObject)
    {
        float startAlpha = 0;
        SpriteRenderer objectColor = gameObject.GetComponent<SpriteRenderer>();
        objectColor.color = new Color(1, 0, 0, 1);
        while (startAlpha < 1.0f)
        {
            startAlpha += 0.08f;
            yield return new WaitForSeconds(0.01f);
            if (objectColor == null) // objectColor가 null인지 체크
                yield break; // null이면 코루틴 종료
            objectColor.color = new Color(1, startAlpha, startAlpha, 1);
        }
    }
}