using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Kenney.nl om ni vill använda andra tilemap assets

    /// <summary>
    /// Rigidbody component - Den är satt som private för både komponenten och scriptet sitter på samma spelobjekt
    /// För att undvika reference error så tar jag "GetComponent av Rigidbody i Start
    /// </summary>
    private Rigidbody2D rb;
    //Movement input
    private float horizontalMovement;

    /// <summary>
    /// Jag använder Header attribute så man kan dela upp det i projektet. Anledningen till detta är för det kan hända att man har 10+ olika variabler
    /// från scriptet så det kan bli rörigt att hitta variabler.
    ///
    /// Anledningen till att jag använder SerializeField är för variablerna är private samtidigt som jag vill ändra variablerna i Inspectorn.
    /// Det kan förekomma att variabler behöver vara public, men i det här fallet så är det bäst att sätta de till SerializeField så man inte referrar
    /// i andra scripts och man har svårt att hitta vad som ställer till det.
    /// </summary>
    [Header("Movement Variable")]
    [SerializeField] private float moveSpeed;
    [Header("Jumping Variables")]
    [SerializeField] private float jumpForce;

    [Header("Ground Check")]
    //Ground check empty gameobject på spelaren
    [SerializeField] private Transform groundCheckPoint;
    //Ändra storleken på groundcheck i inspectorn, Jag använder OnDrawGizmos för debugging och lättare att se storleken.
    [SerializeField] private Vector2 groundCheckSize;
    //Layermask som är skapad i Layers högst upp i Inspectorn
    [SerializeField] private LayerMask groundLayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //Update körs i varje frame, ett bra exempel att använda detta är för Input, FixedUpdate används mest för Physics som med Rigidbody2D
    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        //Om spelaren är på marken så körs Input villkoret, annars om man är i luften så körs den inte så man hoppar flera gånger när spelaren ä i luften
        if (IsGrounded())
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //kör en Vector2 för att kolla hur högt spelaren ska hoppa
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.5f);
            }
        }

        Debug.Log(horizontalMovement + " Horizontal movement");
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        //Vector2 för att läsa spelar input och multiplicerar hur snabbt spelaren ska springa
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        //Kollar på groundcheck position och size samt groundlayer för att se om spelaren är på marken
        if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }

        return false;
    }

    //Debug för att rita en visuell ground check
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
    }
}
