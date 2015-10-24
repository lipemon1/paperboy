using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class JogaJornal : MonoBehaviour {
	// Use this for initialization
	private Rigidbody rb;
	private GameObject trower;
	private float tempoDeVida;
	void Start () {
		rb = GetComponent<Rigidbody>();
		trower = GameObject.Find("JornalTrower");
		tempoDeVida = 5;
		//aplica o trow
		transform.eulerAngles = new Vector3(0, trower.transform.eulerAngles.y, 0);
		rb.AddRelativeForce(Vector3.forward * trower.GetComponent<DragAndTrow>().forca * 200);
		rb.AddForce(Vector3.up * trower.GetComponent<DragAndTrow>().forca * 80);
	}
	
	// Update is called once per frame
	void Update () {
		tempoDeVida -= Time.deltaTime;
		if(tempoDeVida <= 0)
			Destroy(this.gameObject);
	}
}