using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
	public Sprite[] Sprites;
	
	public void SwitchImage(int index)
	{
		GetComponent<Image>().sprite = Sprites[index - 1];
	}
}
