using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCanvasYbot : MonoBehaviour {


	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.J))
        {


            Destroy(gameObject);
        }
	}
}
