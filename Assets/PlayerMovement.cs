using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float freezeSpeed = 0;
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float cameraSpeed;

    private float x, y;

    public bool hide = false;
    public bool moving;

    public bool isPaused = false;



    float speedX, speedY;
    Vector2 input;




    [Header("Auto Assign")]
    [SerializeField] private GameObject camera;
    Rigidbody2D rb;
    [SerializeField] SpriteRenderer playerMesh;
    [SerializeField] Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        playerMesh = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
            return;


        GetInput();
        Animate();


        if (!hide)
        {
            speedX = Input.GetAxisRaw("Horizontal") * speed;
            speedY = Input.GetAxisRaw("Vertical") * speed;
            rb.velocity = new Vector2(speedX, speedY);
            playerMesh.enabled = true;
            speed = walkSpeed;

        }
        else
        {
            speedX = Input.GetAxisRaw("Horizontal") * speed;
            speedY = Input.GetAxisRaw("Vertical") * speed;
            rb.velocity = new Vector2(speedX, speedY);
            speed = freezeSpeed;
            playerMesh.enabled = false;
            speed = freezeSpeed;




            if (Input.GetKeyDown(KeyCode.F))
            {
                hide = false;
            }

        }

        Vector3 targetPosition = gameObject.transform.position;
        targetPosition.z = -10;
        camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, cameraSpeed * Time.deltaTime);

    }

    void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        input = new Vector2(x, y);
        input.Normalize();
    }

    void Animate()
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("Moving", moving);


    }
}
