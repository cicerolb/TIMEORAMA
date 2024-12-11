using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RizalScript : MonoBehaviour
{
    [SerializeField] bool looking;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Animator anim;

    [SerializeField] GameObject gameOverScreen;

    float randNum;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(LookChance());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isPaused)
            return;

        anim.SetBool("Looking", looking);
        if (looking)
        {
            if (!playerMovement.hide)
            {
                Debug.Log("GameOver");
                StartCoroutine(GameOver());
            }
        }
    }


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Lose");
    }

    IEnumerator LookChance()
    {
        yield return new WaitForSeconds(4f);
        while (true)
        {
            randNum = Random.Range(1, 10);
            Debug.Log(randNum);
            if (randNum >= 5)
            {
                looking = true;
                yield return new WaitForSeconds(1f);
                looking = false;
            }
            yield return new WaitForSeconds(3f);
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            looking = true;
        }
    }
}
