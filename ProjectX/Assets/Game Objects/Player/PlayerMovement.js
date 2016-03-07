var speed : float = 1; 



//Will check every frame
function Update () {


//Go Left
if (Input.GetKey ("left")) 
{
transform.Translate(Vector3(-speed,0,0) * Time.deltaTime);
 //GetComponent.<Rigidbody2D>().AddForce(Vector2(-1,0) * 10);
}

//Go right
if (Input.GetKey ("right"))
{
transform.Translate(Vector3(speed,0,0) * Time.deltaTime);
 //GetComponent.<Rigidbody2D>().AddForce(Vector2.right * 10);
}

//Jump
if(Input.GetKeyDown(KeyCode.Space))
{
 GetComponent.<Rigidbody2D>().AddForce(new Vector2(0, 300 ));
}


}
