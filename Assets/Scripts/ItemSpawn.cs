using System.Collections;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public static ItemSpawn Instance;
    public int ranNum;
    public GameObject Item1;
    public GameObject Item2;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void RandomItem(Transform transform)
    {
        ranNum = Random.Range(-1, 2);
        if(ranNum == -1)
        {
            Instantiate(Item1, transform.position, Quaternion.identity);
        }
        else if(ranNum == 1)
        {
            Instantiate(Item2, transform.position, Quaternion.identity);
        }
    }
    
}
