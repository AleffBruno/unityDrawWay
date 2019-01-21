using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
	// power ups para pegar tintas para poder desenhas o caminho __OK
	// detectar manobras para dar tinta __OK
	// fazer fases somente de manobras
	// quanto mais giros, mais os pontos se multiplicam __NOP > manter a tela limpa, talvez na versao 2
	// efetiso especiais : explosao , rastro de fogo quando andar mt rapido, distanciar camera em determinados momentos
	// carros inimigos seguem, se encostar morre
	// timer __NOP > deixe o game facil, talve na versao 2
	// shop: aumentar capacidade de tinta
	// explode carro se uma linha passar no meio dele __FAIL
	// stuff de aceletar o carro e deixar rastro de chama
	// objetos dinamicos nas fases
	// fazer fim da fase
	// pause

	// detectar se esta na pista ou no ar  __NOP > sem sentido
	// check complete rotation unity __OK


	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;
	public bool destroyMySelf;

	List<Vector2> points;
	public Player player;

	void Awake() {
		//Car = GameObject.Find("car (1)");
		player = GameObject.Find("car (1)").GetComponent<Player>();
	}
	void Start() {

		if(destroyMySelf) {
			StartCoroutine(startDestroyLine());
		}
		//print(edgeCol.points.ToArray());

		//var foos = new List<Vector2>(edgeCol.points).ToArray();
		//print(foos[0]);
	}

	public void UpdateLine (Vector2 mousePos) {
		if (points == null) {
			points = new List<Vector2>();
			SetPoints(mousePos);
			return;
		}
			
		// check the distance between one point and another point to see if greater tha .1f
		if (Vector2.Distance(points.Last(),mousePos) > .1f ) {
			SetPoints(mousePos);
		}
	}

	public void SetPoints (Vector2 point) {
		points.Add(point);

		lineRenderer.numPositions = points.Count;
		//lineRenderer.positionCount = points.Count; //the above is obsolete, this is the current
		lineRenderer.SetPosition(points.Count -1,point);

		if (points.Count > 1) {
			edgeCol.points = points.ToArray();
		}
	}

	IEnumerator startDestroyLine () {
		yield return new WaitForSeconds(1);
		StartCoroutine(DestroyLine());
	}

	IEnumerator DestroyLine(int x = 1) {
		var arraySyncPointsEdgeCollider = new List<Vector2>(edgeCol.points).ToArray();

		for(int i=0;i<=x;i++){
			lineRenderer.SetPosition(i,lineRenderer.GetPosition(x));
			arraySyncPointsEdgeCollider[i] = arraySyncPointsEdgeCollider[x];
		}
		edgeCol.points = arraySyncPointsEdgeCollider;
		if(x+1 <= lineRenderer.positionCount-1) {
			yield return new WaitForSeconds(0.05f);
			StartCoroutine(DestroyLine(x+1));
		}else{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "triggertodieplayer"){
			player.explodeMyself();
			print("ontrigerenter");
			//AINDA TA BUGADO !!!
			//Destroy(Car);
			//MATA PLAYER AQUI SE A LINHA ATRAVESSAR ELE
		}
	}

	void guardandoLogicaPassada() {
		/*
		var foos = new List<Vector2>(edgeCol.points);
		print(foos.Count);
		foos.RemoveAt(1);
		print(foos.Count);
		//return foos.ToArray();
		print(foos.ToArray());
		*/
	}
}
