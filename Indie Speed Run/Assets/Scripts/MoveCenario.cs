using UnityEngine;
using System.Collections;

public class MoveCenario : MonoBehaviour {
	public float velocidade = 1;
	public Transform emFrente;
	public GameObject[] casa;
	// Use this for initialization
	void Start () {
		Resetar();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.forward * Time.deltaTime * velocidade);
		if(transform.position.z < -20){
			Resetar();
		}
	}

	void Resetar() {
		int safe = Random.Range(0, casa.Length);
		for(int i = 0; i < casa.Length; i++){
			if(i != safe)
				casa[i].SetActive(false);
			else
				casa[i].SetActive(true);
		}
		transform.position = new Vector3(transform.position.x, transform.position.y, emFrente.position.z + 19.9f);
	}
}
