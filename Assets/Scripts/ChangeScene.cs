using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    // 씬 매니저 클래스는 유니티에서 씬을 관리하는 클래스입니다.
    // UnityEngine.SceneManagement가 using 인 상태에서 사용이 가능합니다.

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Load(sceneName);
        }
    }

}
