using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_script : MonoBehaviour
{
	public bool pointcol = false;
	public RectTransform textpoint;
	public GameObject panelgameover;
	public GameObject panelwingame;

	public bool gamewin = false;
	public bool gameover = false;


	public int i = 0;
	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "pointtag")
		{
			pointcol = true;
			//Destroy(other.gameObject);
		}
		if(other.gameObject.tag == "octtag")
		{
			panelgameover.SetActive(true);
			gameover = true;
		}
		if(other.gameObject.tag == "wintag")
		{
			panelwingame.SetActive(true);
			gamewin = true;
			gameover = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "pointtag")
		{
			pointcol = false;
			Destroy(other.gameObject);
			i++;
			textpoint.GetComponent<Text>().text = i.ToString();
			//Debug.Log(i);
			//textpoint.gameObject.GetComponentInChildren<Text>().
		}
	}
}
