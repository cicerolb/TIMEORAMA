using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject item1, item2, item3;
    float randNum;
    // Start is called before the first frame update
    void Start()
    {
        randNum = Random.Range(1, 4);
        if (randNum == 1)
        {
            item1.SetActive(true);
        }
        else if (randNum == 2)
        {
            item2.SetActive(true);
        }
        else if (randNum == 3)
        {
            item3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
