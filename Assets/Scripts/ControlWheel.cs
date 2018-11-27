using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWheel : MonoBehaviour {

    public GameObject wheel;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public AnimationCurve myCurve;

    protected bool buttonPressed1, buttonPressed2, buttonPressed3, buttonPressed4;

    // Use this for initialization
    void Start () {
        wheel = transform.GetChild(0).gameObject;
        button1 = transform.GetChild(1).gameObject;
        button2 = transform.GetChild(2).gameObject;
        button3 = transform.GetChild(3).gameObject;
        button4 = transform.GetChild(4).gameObject;

        myCurve = AnimationCurve.EaseInOut(0f, .95f, 1f, 1.05f);
        myCurve.preWrapMode = WrapMode.PingPong;
        myCurve.postWrapMode = WrapMode.PingPong;

        buttonPressed1 = buttonPressed2 = buttonPressed3 = buttonPressed4 = false;

    }

    void hoverButton(GameObject o) {
        Vector3 buttonPos = o.transform.position;
        o.transform.position = new Vector3(buttonPos.x, myCurve.Evaluate((Time.time % myCurve.length)), buttonPos.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            buttonPressed1 = !buttonPressed1;
            buttonPressed2 = buttonPressed3 = buttonPressed4 = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            buttonPressed2 = !buttonPressed2;
            buttonPressed1 = buttonPressed3 = buttonPressed4 = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            buttonPressed3 = !buttonPressed3;
            buttonPressed2 = buttonPressed1 = buttonPressed4 = false;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            buttonPressed4 = !buttonPressed4;
            buttonPressed2 = buttonPressed3 = buttonPressed1 = false;
        }

        if (buttonPressed1) {
            //Fetch the Renderer from the GameObject
            Renderer rend = button1.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.red);
            hoverButton(button1);
        } else {
            //Fetch the Renderer from the GameObject
            Renderer rend = button1.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.grey);
        }
        if (buttonPressed2) {
            //Fetch the Renderer from the GameObject
            Renderer rend = button2.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.red);
            hoverButton(button2);
        } else {
            //Fetch the Renderer from the GameObject
            Renderer rend = button2.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.grey);
        }
        if (buttonPressed3) {
            //Fetch the Renderer from the GameObject
            Renderer rend = button3.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.red);
            hoverButton(button3);
        } else {
            //Fetch the Renderer from the GameObject
            Renderer rend = button3.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.grey);
        }
        if (buttonPressed4) {
            //Fetch the Renderer from the GameObject
            Renderer rend = button4.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.red);
            hoverButton(button4);
        } else {
            //Fetch the Renderer from the GameObject
            Renderer rend = button4.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.grey);
        }


    }
}
