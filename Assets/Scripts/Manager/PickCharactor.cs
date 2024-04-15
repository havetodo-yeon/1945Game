using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PickCharactor : MonoBehaviour
{
    public GameObject Usable;
    //public TextMeshProUGUI Usable;
    public VideoPlayer player;
    public VideoClip[] clip;

    private void Start()
    {
        Usable.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            player.clip = clip[0];
            StartCoroutine(activing());
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            player.clip = clip[1];
            StartCoroutine(activing());
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.able = true;
        }
    }

    IEnumerator activing()
    {
        Usable.SetActive(true);
        yield return new WaitForSeconds(1f);
        Usable.SetActive(false);
    }

}
