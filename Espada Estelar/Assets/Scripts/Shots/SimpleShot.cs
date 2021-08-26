using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShot : MonoBehaviour
{

    public GameObject bullet;
    public Transform initPosition;
    public float velocity;
    public float coolDown;
    private float shootWhen;
    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time > shootWhen)
        {
            smoke.Play();
            GameObject bulletInst;
            bulletInst = Instantiate(bullet, initPosition.position, initPosition.rotation);
            bulletInst.GetComponent<Rigidbody>().AddForce(initPosition.right * 100 * velocity);
            shootWhen = Time.time + coolDown;
           
            Destroy(bulletInst, 1f);

        }

    }
}
