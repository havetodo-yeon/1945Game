using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Image startImage;

    public Image FadeImage;
    [SerializeField] GameObject textBossWarning;    // 보스 텍스트 오브젝트

    public Sprite[] ScoreImages;    // 숫자 이미지 소스
    public Image[] ScoreAppear;    // 숫자 이미지

    public int scoreCount = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        textBossWarning.SetActive(false);
    }

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

    public void BossTextSet(string text, float time)
    {
        textBossWarning.SetActive(true);
        textBossWarning.GetComponent<TextMeshProUGUI>().text = text;
        Invoke("BossTextHide", time);
    }

    public void BossTextHide()
    {
        textBossWarning.SetActive(false);
    }

    public void Fade()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float currentA = 0;
        while(currentA < 0.95f)
        {
            currentA += 0.01f;
            yield return new WaitForSeconds(0.01f);
            FadeImage.GetComponent<Image>().color = new Color(0, 0, 0, currentA);

        }
    }

    public void ScoreSet(int score)
    {
        scoreCount = scoreCount + score;
        for(int i = 0; i < scoreCount.ToString().Length; i++)
        {
            //Debug.Log(int.Parse(scoreCount.ToString()[i].ToString()) +  " / " + i);
            ScoreAppear[-1 + scoreCount.ToString().Length - i].sprite = ScoreImages[int.Parse(scoreCount.ToString()[i].ToString())];
        }
    }


}
