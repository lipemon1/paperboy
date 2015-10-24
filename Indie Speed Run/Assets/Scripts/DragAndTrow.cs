using UnityEngine;
using System.Collections;

public class DragAndTrow : MonoBehaviour {
	//os pontos do drag
	public Transform pontoInicio, pontoFinal;
	public LayerMask mask;
	public GameObject jornal;
	public  float forca;
	//Use this for initialization
	void Start () {
		mask  = -LayerMask.NameToLayer("Floor");
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		//toda logica de drag vai aqui
		Physics.Raycast(ray, out hit, 200, mask);
		float dist = Vector3.Distance(pontoInicio.transform.position, pontoFinal.transform.position);

		if(Input.GetButtonDown("Fire1")){		
			pontoInicio.position = hit.point;
		}
		else if(Input.GetButton("Fire1")){
			pontoFinal.position = hit.point;
			transform.LookAt(hit.point);
			if(dist < 2)
				forca = dist * 2;
		}
		else if(Input.GetButtonUp("Fire1")){
			//executa o lancamento de acordo com a força

			Instantiate(jornal, transform.position, transform.rotation);
		}
			
	}
}