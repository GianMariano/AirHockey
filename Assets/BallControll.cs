using UnityEngine;

public class BallControll : MonoBehaviour
{
    private Rigidbody2D rb2d;               
    public float forcaEmpurrao = 1f;
    public float MaxVelocity = 2f;
    public AudioSource source;
    void GoBall(){
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20, -15));
        } else {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void Start () {
        rb2d = GetComponent<Rigidbody2D>(); 
        Invoke("GoBall", 2);    
        source = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 direcao = (transform.position - coll.transform.position).normalized;

            rb2d.AddForce(direcao * forcaEmpurrao, ForceMode2D.Impulse);
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = (rb2d.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocityY / 3);
            rb2d.linearVelocity = vel;
             if(forcaEmpurrao >MaxVelocity)
            {
                forcaEmpurrao = MaxVelocity;
            }
        }
       source.Play();
    }
    
    void ResetBall(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }
}
