using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class webcamscript : MonoBehaviour {

	public GameObject webCameraPlane;
	public Button fire;

	// Use this for initialization
	void Start () {

		if (Application.isMobilePlatform) {
		      GameObject cameraParent = new GameObject ("camParent");
		      cameraParent.transform.position = this.transform.position;
		      this.transform.parent = cameraParent.transform;
		      cameraParent.transform.Rotate (Vector3.right, 90);
		    }
				Input.gyro.enabled = true;

				fire.onClick.AddListener (OnButtonDown);

		WebCamTexture webCameraTexture = new WebCamTexture();
    webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
    webCameraTexture.Play();

	}


  void OnButtonDown(){

    GameObject torpedo = Instantiate(Resources.Load("torpedo", typeof(GameObject))) as GameObject;
    Rigidbody rb = torpedo.GetComponent<Rigidbody>();
    torpedo.transform.rotation = Camera.main.transform.rotation;
    torpedo.transform.position = Camera.main.transform.position;
    rb.AddForce(Camera.main.transform.forward * 500f);
    Destroy (torpedo, 3);

    GetComponent<AudioSource> ().Play ();


  }

	// Update is called once per frame
	void Update () {

			Quaternion cameraRotation = new Quaternion (Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
			this.transform.localRotation = cameraRotation;
	}
}
