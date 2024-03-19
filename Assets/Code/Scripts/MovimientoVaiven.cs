using UnityEngine;

public class MovimientoVaiven : MonoBehaviour
{
    public float amplitud = 1.0f;
    public float velocidadMovimiento = 2.0f;
    public float posicionInicial;
    public float posicionX;
    // Inicialización de posiciones aleatorias
    void Start()
    {
        //Asignar una posición inicial aleatoria en el eje Y
        float posicionInicial = Random.Range(-amplitud, amplitud);
        transform.position = new Vector3(posicionX, posicionInicial, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular la posición de vaivén
        float desplazamientoY = Mathf.Sin(Time.time * velocidadMovimiento) * amplitud;

        // Aplicar el movimiento sobre el eje Y
        transform.position = new Vector3(posicionX, desplazamientoY, transform.position.z);
    }
}
