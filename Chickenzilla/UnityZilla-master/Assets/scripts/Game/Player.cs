using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	private int life = 4;

    public GameObject grapeController;

    public GameObject score_reference;

    public GameObject ui_life_bar;

    public GameObject new_player_position;


	public float jumpSpeed = 1.0f;
	public float gravity = 30.0f;
	public float gravityForce = 3.0f;
	public float airTime = 1.0f;

	private Vector3 moveDirection = Vector3.zero;
	private float invertGrav;

	private float forceY = 0;

	private bool on_ground = true;

    private float distanceToGround;

    private GameObject[] grounds;

    

    public bool invunerable = false;
    private int time_invunerable = 0;
    const int max_time_invunerable = 60;

    public GameObject drunkImage_reference;
    public bool is_drunk = false;
    public Drunk drunkScript;


    //ANIMATION RUN TO MIDDLE OF SCREEN
    //
    //
    //   

    private Transform original_position;
    private bool running = false;
    private bool direction = false;

    void Start () {
        original_position = gameObject.transform;
        drunkScript = new Drunk();
		invertGrav = gravity * airTime;
        distanceToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
        GetGrounds();
    }


    private void OnTriggerEnter2D(Collider2D collision) {

        switch (collision.gameObject.tag) {

            case "Wave": {
                    if (!invunerable) {
                        CollideWithWave();
                    }
                    break;
            }

            case "Grape": {
                    grapeController.GetComponent<GrapeController>().GetGrape();
                    Destroy(collision.gameObject);
                    break;
            }

            case "Bubbly": {
                    GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().AddScore(4);

                    Destroy(collision.gameObject);
                    break;
            }

            case "Rose": {
                    GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().AddScore(10);

                    Destroy(collision.gameObject);
                        break;
            }

            case "Beer": {
                    Is_Drunk();
                    Destroy(collision.gameObject);
                        break;
            }
        }
        
    }

    public void Is_Drunk()
    {
        is_drunk = true;
        Instantiate(drunkImage_reference);
    }


    private void CollideWithWave()
    {
        life -= 1;
        CheckIfIsDead();
        CheckIfGiantChickenAppears();

        ui_life_bar.GetComponent<UI_life_controller>().ChangePlayerUIPosition(life);
        invunerable = true;
    }

    private void CheckIfGiantChickenAppears()
    {
        if (life == 1)
        {
            grapeController.GetComponent<GrapeController>().EnterChickenMode();
        }
    }

    private void CheckIfIsDead()
    {
        if (life == 0)
            SceneManager.LoadScene("Menu");
    }


    public void GetGrounds()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
    }

    public void CheckIfOnTheGround()
    {
        BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
        if (bc.IsTouching(grounds[0].GetComponent<BoxCollider2D>()))
            on_ground = true;
    }

    public void Jump(){
		
		if (on_ground) {
			forceY = 0;
			invertGrav = gravity * airTime;
			if (Input.GetButton("Jump")) { 
				forceY = jumpSpeed;
                on_ground = false;
            }
        }

		if (Input.GetButton("Jump") && forceY != 0) {
			invertGrav -= Time.deltaTime;
			forceY += invertGrav * Time.deltaTime;
		}

        if (!on_ground) {
		    forceY -= gravity * Time.deltaTime * gravityForce;
		    moveDirection.y = forceY;
		    gameObject.transform.position += (moveDirection * Time.deltaTime);
            CheckIfOnTheGround();
        }

        
    }

    private void CheckIfItsDamaged() {
        if (invunerable){
            GetComponent<BlinkGameObject>().enabled = true;
            UpdateDamageStatus();
        }
    }

    public void GainLife()
    {
        life += 1;
    }

    public int GetLife()
    {
        return life;
    }

    private void UpdateDamageStatus(){
        if (time_invunerable < max_time_invunerable)
            time_invunerable++;
        else {
            invunerable = false;
            time_invunerable = 0;
            GetComponent<BlinkGameObject>().TurnOffTransparency();
            GetComponent<BlinkGameObject>().enabled = false;
        }
    }



    void FixedUpdate () {
        if (grounds == null)
            GetGrounds();
        /*
        if (Input.GetKey("left"))
            transform.Rotate(0, 0, 100 * Time.deltaTime, Space.Self);
        if (Input.GetKey("right"))
            transform.Rotate(0, 0, -100 * Time.deltaTime, Space.Self);
        */

        if (is_drunk) {
            is_drunk = drunkScript.PressSpaceToStopDrunkenness();
        }
        else {
            Jump();
        }
        
        CheckIfItsDamaged();

        /*
        if (running)
            Run();
        else
            CheckPlayerScore();
        */
	}

    private void CheckPlayerScore() {
        int score = score_reference.GetComponent<Score>().GetScore();
        if (score % 10 == 0 && score != 0) {
            running = true;
        }
    }

    private void Run() {

        if (!direction) {
            if (transform.position.x < new_player_position.transform.position.x)
                transform.position += Vector3.right * 4.0f * Time.deltaTime;
            else {
                running = false;
                direction = true;
            }
        }
        else if (direction) {
            if (transform.position.x > original_position.position.x)
                transform.position += Vector3.left * 4.0f * Time.deltaTime;
            else {
                running = false;
                direction = false;
            }
        }
            
    }

}
