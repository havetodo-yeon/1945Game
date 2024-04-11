using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    // �� �Ŵ��� Ŭ������ ����Ƽ���� ���� �����ϴ� Ŭ�����Դϴ�.
    // UnityEngine.SceneManagement�� using �� ���¿��� ����� �����մϴ�.

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
