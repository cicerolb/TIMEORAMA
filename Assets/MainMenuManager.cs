using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] GameObject start, instructions, credits;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButton()
    {
        SceneManager.LoadScene(scene);
    }

    public void InstructionsButton()
    {
        start.SetActive(false);
        instructions.SetActive(true);
    }

    public void CreditsButton()
    {
        credits.SetActive(true);
        start.SetActive(false);
    }

    public void BackButton()
    {
        instructions.SetActive(false);
        start.SetActive(true);
        credits.SetActive(false);
    }
}
