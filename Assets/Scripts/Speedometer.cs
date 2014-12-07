using UnityEngine;
using System.Collections;
using UnitySampleAssets.Vehicles.Car;

public class Speedometer : MonoBehaviour {

	public Texture bottomTexture, topTexture, barTexture;
	public float maxSpeed, currentSpeed;
	public GUIStyle speedometerGUIstyle;

	private Rect rectSize, stringLabelSize, numberLabelSize;
	private string textToDisplay;

	void Start () 
	{
		float xx = Screen.width / 10;
		float yy = Screen.height / 10;
		rectSize = new Rect(xx * 8.80f, yy * 8.1f, xx + 15, xx + 15);
		numberLabelSize = new Rect(xx * 8.80f, yy * 7.8f, xx + 10, xx + 10);
		stringLabelSize = new Rect(xx * 8.80f, yy * 8.4f, xx + 10, xx + 10);
		
		textToDisplay = "Speed";
		maxSpeed = gameObject.GetComponent<CarController>().MaxSpeed;

		speedometerGUIstyle.fontSize = System.Convert.ToInt32(Screen.height * 0.04f);
	}
	
	void Update () 
	{
		currentSpeed = gameObject.GetComponent<CarController>().CurrentSpeed;
	}

	void OnGUI()
	{
		GUI.DrawTexture(rectSize, bottomTexture);
		GetComponent<Renderer>().material.SetFloat("_Cutoff", Mathf.Clamp(Mathf.InverseLerp(0f, maxSpeed, maxSpeed - currentSpeed), .01f, 1));
//		GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Color.clear, Color.white, currentSpeed / maxSpeed));
		Graphics.DrawTexture(rectSize, barTexture, gameObject.GetComponent<Renderer>().material);
		
		GUI.DrawTexture(rectSize, topTexture);
		float currentSpeedToDisplay = currentSpeed<0? 0 : currentSpeed;
		GUI.Label(numberLabelSize, string.Format("{0:f1}", currentSpeedToDisplay), speedometerGUIstyle);
		GUI.Label(stringLabelSize, textToDisplay, speedometerGUIstyle);

	}
}
