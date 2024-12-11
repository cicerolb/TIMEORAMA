using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CabinetManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] float dist;
    AudioSource audioSource;
    [SerializeField] AudioClip audio;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            dist = Vector3.Distance(gameObject.transform.position, player.transform.position);

            if (dist < 3)
            {
                audioSource.PlayOneShot(audio);
                playerMovement.hide = true;
            }
        }
    }
}
