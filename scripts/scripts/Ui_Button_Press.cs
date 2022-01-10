using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Button_Press : MonoBehaviour { 

	public Button yourButton;
	public GameObject myPrefab;
void Start()
{
	Button btn = yourButton.GetComponent<Button>();
	btn.onClick.AddListener(TaskOnClick);
}

void TaskOnClick()
{
		myPrefab.SetActive(true);
		Debug.Log("You have clicked the button!");
}
}
