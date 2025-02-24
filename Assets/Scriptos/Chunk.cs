using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    [SerializeField] bool instanciarAlIniciar;
    [SerializeField] List<Transform> pivotes = new List<Transform>();
    [SerializeField] List<GameObject> obstaculosInstanciados = new List<GameObject>();

    private void Start()
    {
	//Si la variable booleana es verdadera, entonces:
        if (instanciarAlIniciar == true)
        {
	//Llame a la funcion GenerarObstaculos
        GenerarObstaculos();
        }
    }



    public void GenerarObstaculos()
    {
        //Al generar nuevos obstáculos en el chunk, eliminamos los que fueron instanciados anteriormente.
        DestruirObstaculos();

	//Ciclo for cuyo indice inicia en 0 hasta que el indice sea menor que la cantidad de elementos en la lista Pivotes
        for (int i = 0; i < pivotes.Count; i++)
        {
	//Creamos un random que incluye el parametro uno que es: 1 y excluye el parametro 2 que es: 6
            int randomNum = Random.Range(1, 6);
	//Creamos una variable de tipo GAMEOBJECT que recibe una instancia de la carpeta "Resources" de 'Assets/Resources', cargando un objeto 
	// en este caso se llama 'Obstaculo' y como hay 5, le concatenamos el numero random que creamos antes.
	// como segundo parametro es el Pivote ACTUAL
            GameObject obstaculo = (GameObject)Instantiate(Resources.Load("Obstaculo"+randomNum), pivotes[i]);            
	//ahora la posicion local del Obstaculo será 0 en todos los ejes (Vector3.zero = (0x, 0y, 0z))
            obstaculo.transform.localPosition = Vector3.zero;

            //Guardamos el obstáculo instanciado para poder eliminarlo luego
            obstaculosInstanciados.Add(obstaculo);
        }
        
    }


    public void DestruirObstaculos()
    {
        //Eliminamos todo los obstaculos instanciados anteriormente
        for (int i = 0; i < obstaculosInstanciados.Count; i++)
        {
            Destroy(obstaculosInstanciados[i]);
        }

        obstaculosInstanciados.Clear();
    }
}
