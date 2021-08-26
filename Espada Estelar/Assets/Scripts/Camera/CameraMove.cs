using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{


    [SerializeField]
    KeyCode lookBack;



    private int lookingAt = 1;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    private float waitFor;
    public float coolDown;
    public float coolDownFliping;


    // Start is called before the first frame update
    void Start()
    {
        print("entra a 1");
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(lookBack) && Time.time > waitFor)
        {
            waitFor = Time.time + coolDown;
            lookingAt++;
            if (lookingAt == 1)
            {
                print("entra a 1");
                cam1.SetActive(true);
                cam2.SetActive(false);
                cam3.SetActive(false);

            }
            else if (lookingAt == 2)
            {
                print("entra a 2");
                cam1.SetActive(false);
                cam2.SetActive(true);
                cam3.SetActive(false);


            }
            else if (lookingAt == 3)
            {
                print("entra a 3");
                cam1.SetActive(false);
                cam2.SetActive(false);
                cam3.SetActive(true);
                lookingAt = 0;
            }
        }
    }
}
