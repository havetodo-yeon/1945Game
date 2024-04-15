using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPColor : MonoBehaviour
{
    [SerializeField] float lerpTime = 0.1f;
    TextMeshProUGUI textBossWarning;

    // 객체를 비활성화 할 때는 start함수
    private void Awake()
    {
        // 캐싱
        textBossWarning = GetComponent<TextMeshProUGUI>();
    }

    // 활성화가 되면
    private void OnEnable()
    {
        // 코루틴 실행
        StartCoroutine("ColorLerpLoop");
    }

    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            // 색상을 하얀색에서 빨간색으로
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            // 색상을 하얀색에서 빨간색으로
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));

        }
    }

    IEnumerator ColorLerp(Color StartColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        while (percent < 1)
        {
            // lerpTime 시간동안 while() 반복문 실행
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            // 폰트 색상을 Start에서 End로 변경
            textBossWarning.color = Color.Lerp(StartColor, endColor, percent);

            // 한 프레임 기다림
            yield return null;

        }
    }

}
