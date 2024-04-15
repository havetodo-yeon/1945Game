using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public string sceneName;
    static public bool able = false;

    // 씬 매니저 클래스는 유니티에서 씬을 관리하는 클래스입니다.
    // UnityEngine.SceneManagement가 using 인 상태에서 사용이 가능합니다.
    private void Awake()
    {
        able = false;
    }

    public void Load(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && able)
        {
            able = false;
            Load(sceneName);
        }
    }

}
