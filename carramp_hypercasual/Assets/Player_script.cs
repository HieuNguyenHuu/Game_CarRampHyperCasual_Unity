using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_script : MonoBehaviour
{
    public float forwardforce;
    public float outforce;
    public Transform[] wheel;
    public bool runcar;
    public bool startgame = false;
    public GameObject texts;
    public GameObject buttons;
    public GameObject textt;


    Vector3 positionstand;

	private void Awake()
	{
        wheel = transform.GetComponentsInChildren<Transform>();
	}

	// Start is called before the first frame update
	void Start()
    {
        positionstand = transform.position;
        //gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0,0,-0.1f);
    }

	private void OnCollisionEnter(Collision collision)
	{

	}

    public void startgamef()
	{
        startgame = true;
	}

	// Update is called once per frame
	void Update()
    {

        if (startgame)
        {
            texts.SetActive(false);
            buttons.SetActive(false);
            textt.SetActive(true);

            if (!gameObject.GetComponentInChildren<Point_script>().gameover)
            {
                for (int i = 1; i < 5; i++)
                {
                    wheel[i].Rotate(Vector3.right * forwardforce);
                }
                if (Input.GetKey("w"))
                {
                    runcar = false;
                }
                if (Input.GetKeyDown("w"))
                {
                    positionstand = transform.position;
                }
                if (transform.position.y <= 0.05f)
                    runcar = true;
                //else runcar = false;
                //Debug.Log(runcar);
            }
        }
    }

	private void FixedUpdate()
	{
        if(startgame)

        if (!gameObject.GetComponentInChildren<Point_script>().gameover)
        {
            if (runcar)
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * forwardforce * Time.deltaTime;
            else
                gameObject.GetComponent<Rigidbody>().AddForce(0, 0, outforce);
        }
        //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0.3f,1) * outforce;
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * forwardforce;
        //if (runcar)
        //gameObject.GetComponent<Rigidbody>().AddForce(0, 0, forwardforce*Time.deltaTime);
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * forwardforce;
    }
}
