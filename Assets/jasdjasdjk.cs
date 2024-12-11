using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class jasdjasdjk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Main Menu");
    }
}
