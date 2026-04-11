using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float fuerzaRetroceso = 15f;
    public float velocidadMaximaX = 8f;

    [Header("Munición")]
    public int balasIzquierda = 10;
    public int balasDerecha = 10;

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
        inputIzquierda = Input.GetKeyDown(KeyCode.LeftArrow);//aca cambie el input.getkey por el input.getkeydown porque al apretarse cualquier boton de movimiento... Lucas
        inputDerecha = Input.GetKeyDown(KeyCode.RightArrow);//...se gastaba una bala por frame al mantener apretado y como corre a muchos FPS, se quedaba sin balas en un toque. Lucas

        if (inputIzquierda && PuedeDispararIzquierda())
        {
            Disparar(Vector2.left);
            balasIzquierda--;
        }
        // aca saque el else por una cuestion de que no me esta dejando moverme una vez que dispare hacie algun lado. Lucas
        if (inputDerecha && PuedeDispararDerecha())
        {
            Disparar(Vector2.right);
            balasDerecha--;
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(rb.linearVelocity.x) > velocidadMaximaX)// aca tuve que simplificar la funcion porque estaba de mas el if inputizquierda / ...derecha. Lucas
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * velocidadMaximaX, rb.linearVelocity.y);
        }
    }

    bool PuedeDispararIzquierda()
    {
        return balasIzquierda > 0;
    }

    bool PuedeDispararDerecha()
    {
        return balasDerecha > 0;
    }

    void Disparar(Vector2 direccion)
    {
        // Aplica fuerza en sentido contrario
        rb.AddForce(-direccion * fuerzaRetroceso, ForceMode2D.Impulse);

        // Acá podés agregar efectos, sonido, etc.
        Debug.Log("Disparo hacia: " + direccion);
    }
}
