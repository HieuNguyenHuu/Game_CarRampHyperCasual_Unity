using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_script : MonoBehaviour
{
    public Transform[] l_land;
    public Transform Endtransform;
    public Transform Starttransform;
    public Transform fourwayland;
    private void Awake()
	{
        l_land = gameObject.GetComponentsInChildren<Transform>();
        Vector3 maxpoision = l_land[1].position;
        Vector3 minpoision = l_land[1].position;
        for(int i =1; i < l_land.Length;i++)
        {
            maxpoision = Vector3.Max(l_land[i].position, maxpoision);
            if (l_land[i].position == maxpoision)
            {
                Endtransform = l_land[i];
            }
            minpoision = Vector3.Min(l_land[i].position, minpoision);
            if (l_land[i].position == minpoision)
            {
                Starttransform = l_land[i];
            }
        }

    }
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
