using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float velocidadRotacion = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Rotar el GameObject sobre su propio eje vertical
        transform.Rotate(Vector3.forward, velocidadRotacion * Time.deltaTime);
    }
}