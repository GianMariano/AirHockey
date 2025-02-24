using UnityEngine;

public class PlayerVermelhoIA : MonoBehaviour
{
    public Transform bola; 
    public float velocidadeMovimento = 5f; 
    public Vector2 limiteMinimo; 
    public Vector2 limiteMaximo; 
    public Vector2 posicaoInicial; 
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = posicaoInicial;
    }
    void Update()
    {
        if (bola != null)
        {
            Vector2 direcao = (bola.position - transform.position).normalized;
            Vector2 novaPosicao = (Vector2)transform.position + direcao * velocidadeMovimento * Time.deltaTime;
            novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteMinimo.x, limiteMaximo.x);
            novaPosicao.y = Mathf.Clamp(novaPosicao.y, limiteMinimo.y, limiteMaximo.y);
            rb.MovePosition(novaPosicao);
        }
    }
}