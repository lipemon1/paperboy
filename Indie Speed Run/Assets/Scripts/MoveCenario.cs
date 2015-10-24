using UnityEngine;
using System.Collections;

public class MoveCenario : MonoBehaviour {
	[System.Serializable]
	public class Lote{
		public GameObject casa;
		public GameObject parede;
		public GameObject telhado;
	}
	public Lote[] lote;
	public Material[] corParede;
	public Material[] corTelhado;
	public float velocidade = 1;
	public Transform emFrente;


	// Use this for initialization
	void Start () {
		ResetarCenario();
		transform.Translate(-Vector3.forward * 20);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.forward * Time.deltaTime * velocidade);
		if(transform.position.z < -20){
			ResetarCenario();
			ResetarPosicao();
		}
	}

	void ResetarCenario() {
		int safe = Random.Range(0, lote.Length);
		for(int i = 0; i < lote.Length; i++){
			if(i != safe)
				lote[i].casa.SetActive(false);
			else{
				lote[i].casa.SetActive(true);
				lote[i].parede.GetComponent<MeshRenderer>().material = corParede[Random.Range(0, corParede.Length)];
				lote[i].telhado.GetComponent<MeshRenderer>().material = corTelhado[Random.Range(0, corTelhado.Length)];
			}
		}
	}

	void ResetarPosicao(){
		transform.position = new Vector3(transform.position.x, transform.position.y, emFrente.position.z + 19);
	}
}
