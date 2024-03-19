using UnityEngine;

public class MovimientoVaivenH : MonoBehaviour
{
    public float amplitud = 1.0f;
    public float velocidadMovimiento = 2.0f;
    public float posicionInicialX;
    public float posicionX;

    // Inicialización de posiciones aleatorias
    void Start()
    {
        // Asignar una posición inicial aleatoria en el eje X
        float posicionInicialX = Random.Range(-amplitud, amplitud);
        transform.position = new Vector3(posicionInicialX, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular la posición de vaivén
        float desplazamientoX = Mathf.Sin(Time.time * velocidadMovimiento) * amplitud;

        // Aplicar el movimiento sobre el eje X
        transform.position = new Vector3(desplazamientoX, transform.position.y, transform.position.z);
    }
}
