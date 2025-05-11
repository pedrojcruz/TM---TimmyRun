    using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float playerSpeed = 2f; // Speed of the player
    public float horizontalSpeed = 3f; // Speed of the player in the horizontal direction
    public float limiteEsquerdo = -3f; // Limite mínimo no eixo X
    public float limiteDireito = 3f;   // Limite máximo no eixo X

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World); 
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }
        float posX = Mathf.Clamp(transform.position.x, limiteEsquerdo, limiteDireito);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }


}
