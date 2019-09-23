using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class CompletePlayerController : MonoBehaviour {

	public float speed;				
	public Text countText;			
	public Text winText;
    private int Lives;
    private Rigidbody2D rb2d;		
	private int count;
    public Text LivesText;
    public Text LooseText;

    void Start()

	{
		
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;		
		winText.text = "";
        SetCountText ();
        Lives = 3;
        LivesText.text = " ";

    }


    void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb2d.AddForce (movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

	void OnTriggerEnter2D(Collider2D other) 
	{

    

        if (other.gameObject.CompareTag ("PickUp")) 
		{
		
			other.gameObject.SetActive(false);
			count = count + 1;
		
			SetCountText ();
         
            SetLivesText();

        }

        if (other.gameObject.CompareTag("BadPickUp"))
        {
           
            other.gameObject.SetActive(false);
            count = count - 1;

            SetCountText();
            Lives = Lives - 1;
            SetLivesText();

        }
        if (count == 12)
        {
            transform.position = new Vector3(0, 60, 0);
        }

    }
  
    
    void SetCountText()
	{
		
		countText.text = "Count: " + count.ToString ();

		if (count >= 20)
			winText.text = "You win!";
	}
    void SetLivesText()
    {
        LivesText.text = "Lives: " + Lives.ToString();

        if (Lives == 0)
            LooseText.text = "you loose ";
        }
    }

