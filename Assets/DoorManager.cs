using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorManager : MonoBehaviour
{
    [SerializeField] float dist;
    GameObject player;
    GameObject[] items;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
        items = GameObject.FindGameObjectsWithTag("Item");

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dist < 4)
            {
                if (items.Length == 0)
                {
                    SceneManager.LoadScene("Pay");
                }
                else
                {
                    SceneManager.LoadScene("Lose");
                }
            }

        }

    }

}
