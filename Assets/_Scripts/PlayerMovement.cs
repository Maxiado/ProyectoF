using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float fuerzaRetroceso = 15f;
    public float velocidadMaximaX = 8f;

    private Rigidbody2D rb;
    private bool inputIzquierda;
    private bool inputDerecha;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; 
        rb.linearDamping = 3f; 
    }

    void Update()
    {
        inputIzquierda = Input.GetKey(KeyCode.LeftArrow);
        inputDerecha = Input.GetKey(KeyCode.RightArrow);
        if (inputIzquierda && PuedeDisparar()) {
            Disparar(Vector2.left);
        }
        else if (inputDerecha && PuedeDisparar()) {
            Disparar(Vector2.right);
        }
    }

    void FixedUpdate()
    {
        
        if (inputIzquierda && PuedeDisparar())
        {
            rb.AddForce(Vector2.right * fuerzaRetroceso, ForceMode2D.Force);
        }
        else if (inputDerecha && PuedeDisparar())
        {
            rb.AddForce(Vector2.left * fuerzaRetroceso, ForceMode2D.Force);
        }
        
        if (Mathf.Abs(rb.linearVelocity.x) > velocidadMaximaX)
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * velocidadMaximaX, rb.linearVelocity.y);
        }
    }

    bool PuedeDisparar()
    {
        return true; 
    }

    void Disparar(Vector2 direccion)
    {
    }
}
