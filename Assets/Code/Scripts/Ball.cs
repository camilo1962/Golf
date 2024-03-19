using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Ball   : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private GameObject goalFX;



    [Header("Atributos")]
    [SerializeField] private float maxPower = 10f;
    [SerializeField] private float power = 2f;
    [SerializeField] private float maxGoalSpeed = 4f;
    public GameObject Transformer;
    public GameObject Transformer2;
    public GameObject Transformer3;
    private bool isDragging;
    private bool inHole;

    public GameObject PuttSound;
    public GameObject holeInSound;
    public GameObject splooshSound;

    private AudioSource Putt;
    private AudioSource HoleIn;
    private AudioSource Sploosh;

    void Start()
    {
        //define los sonidos y movimiento
        Putt = PuttSound.GetComponent<AudioSource>();
        HoleIn = holeInSound.GetComponent<AudioSource>();
        Sploosh = splooshSound.GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();      
    }

    private void Update()
    {
        PlayerInput();

       //if(LevelManager.main.outOfStrokes && rb.velocity.magnitude <= 0.2f && !LevelManager.main.levelCompleted)
       //{
       //    LevelManager.main.GameOver();
       //}
    }


    private bool IsReady()
    {
        return rb.velocity.magnitude  <= 0.2f;
    }


    private void PlayerInput()
    {

        if (!IsReady()) return;

        Vector2 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(transform.position, inputPos);

        if(Input.GetMouseButtonDown(0) && distance <= 0.5f) DragStart();
        if (Input.GetMouseButton(0) && isDragging) DragChange(inputPos);
        if (Input.GetMouseButtonUp(0) && isDragging) DragRelease(inputPos);
    }

    private void DragStart()
    {
        isDragging = true;
        lr.positionCount = 2;
    }
    private void DragChange(Vector2 pos)
    {
        Vector2 dir = (Vector2)transform.position - pos;

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, (Vector2)transform.position + Vector2.ClampMagnitude(dir * power/2, maxPower / 2));
    }

    private void DragRelease(Vector2  pos)
    {
        float distance = Vector2.Distance((Vector2)transform.position, pos);
        isDragging = false;
        lr.positionCount = 0;

        if(distance < 1f)
        {
           
            return;
        }
        Putt.Play();
        LevelManager.main.IncreaseStroke();

        Vector2 dir = (Vector2)transform.position - pos;

        rb.velocity = Vector2.ClampMagnitude(dir * power, maxPower);
    }

    private void CheckWinState()
    {
        if (inHole) return;
        
        if(rb.velocity.magnitude <= maxGoalSpeed)
        {
            inHole = true;
            //play the hole in sound
            HoleIn.Play();
            rb.velocity = Vector2.zero;
            gameObject.SetActive(false);

            GameObject fx = Instantiate(goalFX, transform.position, Quaternion.identity);
            Destroy(fx, 2f);
            
            LevelManager.main.LevelComplete();
         
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            CheckWinState();
           
        } 

        if (other.gameObject.CompareTag("TransferGoal") && rb.velocity.x < 7f && rb.velocity.y < 7f)
        {
            //move the ball to the transformer's position
            transform.position = new Vector2(Transformer.transform.position.x, Transformer.transform.position.y);

            HoleIn.Play();
        }
        if (other.gameObject.CompareTag("TransferGoal2") && rb.velocity.x < 7f && rb.velocity.y < 7f)
        {
            //move the ball to the transformer's position
            transform.position = new Vector2(Transformer2.transform.position.x, Transformer2.transform.position.y);

            HoleIn.Play();
        }
        if (other.gameObject.CompareTag("TransferGoal3") && rb.velocity.x < 7f && rb.velocity.y < 7f)
        {
            //move the ball to the transformer's position
            transform.position = new Vector2(Transformer3.transform.position.x, Transformer3.transform.position.y);

            HoleIn.Play();
        }
        if (other.gameObject.CompareTag("Water"))
        {
            // Debug.Log("WET!");
            //stop the ball
            rb.velocity = new Vector2(0f, 0f);
            // establece el arrastre de la pelota en 5
            rb.drag = 5;

            //play the sploosh sound
            Sploosh.Play();
        }
        if (other.gameObject.CompareTag("Arena"))
        {
            // Debug.Log("WET!");
            //stop the ball
            rb.velocity = new Vector2(0f, 0f);
            // establece el arrastre de la pelota en 5
            rb.drag = 5;

            //play the sploosh sound
            //Sploosh.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if the ball exit's the water
        if (other.gameObject.CompareTag("Water"))
        {
            //set the drag to 0.6
            rb.drag = 0.6f;
        }
        //if the ball exit's the water
        if (other.gameObject.CompareTag("Arena"))
        {
            //set the drag to 0.6
            rb.drag = 0.6f;
        }
    }
   


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            CheckWinState();
           
        }
    }


}
