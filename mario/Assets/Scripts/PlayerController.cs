using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
public class PlayerController : MonoBehaviour 
{ 
 	public float speed; 
 	public float jumpForce; 
 	public float superjumpForce;
 	private bool canMove; 
 	private Rigidbody2D theRB2D; 

 	public bool grounded;
 	public LayerMask whatIsGrd;
 	public Transform grdChecker;
 	public float grdCheckerRad;

 // Start is called before the first frame update 
 	void Start() 
 	{ 
 		theRB2D = GetComponent<Rigidbody2D>(); 
		Debug.Log(theRB2D.velocity.y);
 	} 
 // Update is called once per frame 
 void Update() 
 { 
 if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)  { 
 canMove = true; 
 }
 MovePlayer(); 
 Jump(); 
 SuperJump();
 Brake();
 Teleport2();
 Teleport3();
 Dash();
}


 void FixedUpdate()
 { 
	grounded = Physics2D.OverlapCircle(grdChecker.position, grdCheckerRad, whatIsGrd);
 } 
 void MovePlayer() 
 { 
 if(canMove) 
 { 
 theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y); 
 } 
 }  

void Jump()
{
 if(grounded == true)
{
if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
{
 theRB2D.velocity = new Vector2(theRB2D.velocity.x,  jumpForce); 
}
}
}
void SuperJump()
{
 if(grounded == true)
{
if(Input.GetKeyDown(KeyCode.X))
{
 theRB2D.velocity = new Vector2(theRB2D.velocity.x,  10); 
}
}
}

void Brake()
{

if(Input.GetKeyDown(KeyCode.B))
{
 theRB2D.velocity = new Vector2(0 , 0); 
}

}

void Teleport2()
{
if(Input.GetKeyDown(KeyCode.I))
{
 theRB2D.position = new Vector2(0 , theRB2D.position.y); 
}
}

void Teleport3()
{
if(Input.GetKeyDown(KeyCode.O))
{
 theRB2D.position = new Vector2(-theRB2D.position.x , -theRB2D.position.y); 
}
}

void Dash()
{
if(Input.GetKeyDown(KeyCode.P))
{
 theRB2D.velocity = new Vector2(20,  theRB2D.velocity.y); 
}
}

}
