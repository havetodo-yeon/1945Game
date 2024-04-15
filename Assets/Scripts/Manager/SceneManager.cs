using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public string sceneName;
    static public bool able = false;

    // �� �Ŵ��� Ŭ������ ����Ƽ���� ���� �����ϴ� Ŭ�����Դϴ�.
    // UnityEngine.SceneManagement�� using �� ���¿��� ����� �����մϴ�.
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
