using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    public float forwardSpeed = 5f, latSpeed = 7.5f, verSpeed = 5f;
    private float activeforwardSpeed, activelatSpeed, activeverSpeed;
    private float forwardAcc = 2.5f, latAcc = 2f, verAcc = 2f;
    public float lookRateSpeed = 90f;

    private Vector2 lookInput, screenCenter, mouseDist;

    private float rollInput;
    public float rollSpeed = 70f, rollAcc = 15f, flipSpeed = 20f;

    public float coolDown;
    private float waitFor;
    private bool rotating;

    public ParticleSystem motors;

    [SerializeField]
    KeyCode accelerate;


    [SerializeField]
    KeyCode flipKey;

    public float coolDownAcc = 0.02f;
    private float waitAcc;

    // Start is called before the first frame update
    void Start()
    {

        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDist.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDist.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDist = Vector2.ClampMagnitude(mouseDist, 1f);


        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcc * Time.deltaTime);
        transform.Rotate(rollInput*rollSpeed*Time.deltaTime, mouseDist.x * lookRateSpeed * Time.deltaTime, mouseDist.y * lookRateSpeed * Time.deltaTime, Space.Self);


        if (Input.GetKey(flipKey) && Time.time > waitFor)
        {
            waitFor = Time.time + coolDown;
            rotating = true;

        }else if (Time.time <= waitFor && rotating)
        {
            transform.Rotate(180f*Time.deltaTime, 0, 0, Space.Self);
        }
        else
        {
            rotating = false;
        }


        if (Input.GetKey(accelerate) && Time.time > waitAcc)
        {
            waitAcc = Time.time + coolDownAcc;
            motors.Play();
            latSpeed = 40f;
            latAcc = 5f;
            
        }
        else
        {

            latSpeed = 7.5f;
            latAcc = 2f;

        }


        activelatSpeed = Mathf.Lerp(activelatSpeed, Input.GetAxisRaw("Horizontal") * latSpeed, latAcc*Time.deltaTime);
        activeforwardSpeed = Mathf.Lerp(activeforwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcc*Time.deltaTime);
        activeverSpeed = Mathf.Lerp(activeverSpeed, Input.GetAxisRaw("Hover") * verSpeed, verAcc*Time.deltaTime);

        transform.position += transform.forward * activeforwardSpeed * Time.deltaTime;
        transform.position += transform.right * activelatSpeed * Time.deltaTime;
        transform.position += transform.up * activeverSpeed * Time.deltaTime;



    }
}
