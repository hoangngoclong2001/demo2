using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float speed = 8f;
	private Rigidbody2D myBody;
    public Unit unitControl;
    //The different keys we need
    private Command buttonA, buttonD;
    //The box we control with keys
    public Transform boxTrans;

    void Awake(){
		myBody = GetComponent<Rigidbody2D> ();

	}

	// Use this for initialization
	void Start () {
        buttonA = new MoveLeft();
        buttonD = new MoveRight();

    }

	void Update(){
        HandleInput();
    }
    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            buttonA.Execute(boxTrans, buttonA);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            buttonD.Execute(boxTrans, buttonD);
        }
    }


   
}
