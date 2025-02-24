using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector2 limiteMinimo; 
    public Vector2 limiteMaximo; 
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float posX = Mathf.Clamp(mousePos.x, limiteMinimo.x, limiteMaximo.x);
        float posY = Mathf.Clamp(mousePos.y, limiteMinimo.y, limiteMaximo.y);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}