using UnityEngine;
using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{

   public float velocidad = 0.5f;
   public float impulsoSalto = 5f;

   public Vector3 inicioPersonaje = new Vector3 (1,1,0);

   public Rigidbody2D rb;

   

   public 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       this.transform.position = inicioPersonaje;

       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
   
       Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

       this.transform.Translate(moveInput.x*velocidad,moveInput.y*velocidad, 0);

       // FLIP

       if(moveInput.x < 0)
       {
         this.GetComponent<SpriteRenderer>().flipX = true;

       }
       else if(moveInput.x > 0)
       {
         this.GetComponent<SpriteRenderer>().flipX = false;

       }

       // SALTO
       
       bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();

       if(salto == true)
       {
        Debug. Log("salto");
         rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
         
       }
       
      

      
    }
}
