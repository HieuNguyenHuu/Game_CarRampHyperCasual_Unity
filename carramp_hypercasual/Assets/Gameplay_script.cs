using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay_script : MonoBehaviour
{
    public Transform[] level;
    public Transform car;
    public Transform presentlevel;
    public Transform pastlevel;
    public Transform pointland;
    public Transform point;
    public float maxdistance;
    public float mindistance;
    public int maxclone;
    public int maxmaxclone;
    public RectTransform textpoint;

    public List<Transform> clonearray = new List<Transform>();

    public Transform[] cloneoct;

    public GameObject Winwall;

    Vector3 d;
    int i = 0;


    Vector3 pointstart;

    Vector3 octstart;



    private void Awake()
	{
        car = GameObject.Find("Car").GetComponent<Transform>();
        presentlevel = level[0];
    }
	// Start is called before the first frame update
	void Start()
    {
        //pointlandposition = new Vector3Int(Mathf.FloorToInt(car.position.x),
        //    Mathf.FloorToInt(car.position.y), Mathf.FloorToInt(car.position.z + 4.0f));
        d = car.position + new Vector3(0, 0, 4.0f);
        pointstart = car.position + new Vector3(0, 0, Random.Range(0, 20.0f));
        octstart = car.position + new Vector3(0, 0, Random.Range(70, 80));
        //Debug.Log(level[0].GetComponent<Level_script>().Endtransform.position.z);
        //Instantiate(Winwall.transform, car.position + new Vector3(0, 0, Random.Range(300, 350)), Quaternion.identity);
        Instantiate(Winwall.transform, car.position + new Vector3(0, 0, Random.Range(200, 250)), Quaternion.identity);
        Winwall.gameObject.GetComponent<MeshRenderer>().enabled= false;
    }

    IEnumerator Action()
    {
        if (maxclone >= 0)
        if (i <= maxclone)
        {
            Transform newclone = Instantiate(pointland, d, pointland.rotation);
            
            d += new Vector3(0, 0.3f, 0.5f);

            i++;

            //car.gameObject.GetComponentInChildren<Point_script>().i--;

            maxclone--;

            textpoint.GetComponent<Text>().text = maxclone.ToString();

            car.gameObject.GetComponentInChildren<Point_script>().i--;

            clonearray.Add(newclone);

            yield return new WaitForSeconds(0.5f);
        }

    }
    
    public void reload()
	{
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    // Update is called once per frame
    void Update()
    {
		if (car.gameObject.GetComponent<Player_script>().startgame) 

        if (!car.gameObject.GetComponentInChildren<Point_script>().gameover)
        {

            if(Vector3.Distance(Winwall.transform.position, car.position) <= 50)
			{
                Winwall.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

            maxclone = int.Parse(textpoint.GetComponent<Text>().text);

            /*Instantiate(point, pointstart, Quaternion.identity);

            pointstart += new Vector3(0, 0, Random.Range(0, 40.0f));*/

            /*if(Vector3.Distance(pointstart, presentlevel.GetComponent<Level_script>().Endtransform.position) <= 100)
            {
                Instantiate(point, pointstart, Quaternion.identity);

                pointstart += new Vector3(0, 0, Random.Range(5.0f, 40.0f));
            }*/

            if (Vector3.Distance(pointstart, car.position) <= 80)
            {
                Instantiate(point, pointstart, Quaternion.identity);

                pointstart += new Vector3(0, 0, Random.Range(5.0f, 20.0f));
            }

            if (Vector3.Distance(octstart, car.position) <= 500)
            {

                Instantiate(cloneoct[Random.Range(0, cloneoct.Length)], octstart, Quaternion.identity);

                octstart += new Vector3(0, 0, Random.Range(40f, 80.0f));
            }


            /*if (car.GetComponentInChildren<Point_script>().pointcol)
            {
                //Debug.Log("point");
            }*/


            float distance = Vector3.Distance(presentlevel.GetComponent<Level_script>().Endtransform.position, car.position);
            //Debug.Log(distance);
            if (distance <= maxdistance)
            {
                pastlevel = presentlevel;
                presentlevel = Instantiate(presentlevel, presentlevel.GetComponent<Level_script>().Endtransform.position + new Vector3(0, 0, 15), Quaternion.identity);
            }
            if (pastlevel != null)
            {
                distance = Vector3.Distance(pastlevel.GetComponent<Level_script>().Starttransform.position, car.position);

                if (distance >= mindistance)
                {
                    Destroy(pastlevel.gameObject);
                }
            }


            if (Input.GetKeyDown("w"))
            {
                d = car.position + new Vector3(0, 0, 0.2f);
                i = 0;
            }
            if (Input.GetKey("w"))
            {
                StartCoroutine(Action());
                /*if (i < maxclone) 
                {
                    Transform newclone = Instantiate(pointland, d, pointland.rotation);
                    d += new Vector3(0, 0.3f, 0.5f);
                    i++;
                    clonearray.Add(newclone);
                }*/
            }

            foreach (Transform e in clonearray.ToArray())
            {
                if (Vector3.Distance(e.position, car.position) >= 20)
                {
                    clonearray.Remove(e);
                    Destroy(e.gameObject);
                }
            }
        }
    }
}
