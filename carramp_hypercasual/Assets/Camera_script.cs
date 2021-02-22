using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    public Transform target;
    public float smoothspeed;
    public Vector3 offset;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        /*Vector3 desiredposition = target.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed * Time.deltaTime);
        transform.position = smoothposition;*/
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
	private void Awake()
	{
        target = GameObject.Find("Car").GetComponent<Transform>();
        offset = gameObject.transform.position;
	}
    // Update is called once per frame
    void Update()
    {
        Vector3 desiredposition = target.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed * Time.deltaTime);
        transform.position = smoothposition;
    }
}
