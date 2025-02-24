using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControladorChunks : MonoBehaviour
{

    [SerializeField] Transform ultimoChunk;
    [SerializeField] float velocidad;
    [SerializeField] List<Chunk> chunks = new List<Chunk>();

    private void Update()
    {
        for (int i = 0; i < chunks.Count; ++i)
        {
	//el Chunk ACTUAL le traducira o tomará su Transform, 
	// PRIMER PARAMETRO: el cual el LEFT (eje X en -1), lo multiplicará por la variable VELOCIDAD (se le da su valor en el inspector) y se multiplica por el tiempo del juego para que corra mas eficazmente
	// SEGUNDO PARAMETRO: Space.World 
            chunks[i].transform.Translate(Vector3.left * velocidad * Time.deltaTime, Space.World);


	//Si la POSICIÓN del  Chunk ACTUAL en el eje X es MENOR O IGUAL a -6 entonces
            if (chunks[i].transform.position.x <= -6)
            {
	//que la NUEVA POSICIÓN del Chunk ACTUAL sea igual a: el último chunk, que ya está declarado al inicio del script Y SE INSTANCIA EN EL INSPECTOR
	// y se suma el RIGHT (eje X en 1) multiplicado por el 6 que sirve para colocarlo al ladito o al lado siguiente del otro chunk, es decir, que los reposicione..
                chunks[i].transform.position = ultimoChunk.transform.position + (Vector3.right * 6);

	//Ahora, el ULTIMO CHUNK (el de mas a la derecha) toma la posición del Chunk ACTUAL, para hacer el efecto de carrusel..
                ultimoChunk = chunks[i].transform;

	//El Chunk ACTUAL, llama a su función de GenerarObstáculos
                chunks[i].GenerarObstaculos();
            }
        }
    }




}
