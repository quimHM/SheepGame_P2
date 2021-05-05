using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;
    
    public GameObject hayBalePrefab; //Reference to the Hay Bale prefab.
    public Transform haySpawnpoint; //The point from which the hay will to be shot. 
    public float shootInterval; //The smallest amount of time between shots
    private float shootTimer; //A timer that to keep track whether the machine can shoot

    public bool hitBySheep = false;
    public int hitPoints = 100;
    public int gamePoints = 0;
    public float gotHayDestroyDelay;
    
    public Material hurtMaterial;
    public Material sharedMaterial;
    public MeshRenderer myRenderer;

    public Text pointsText;
    public Text lifeText;
	public Text loseText;
	public Text winText;

    public bool end = false;

    private void UpdateMovement() {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 1
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) // 2 {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) // 3 {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
            //Debug.Log(transform.position.x);
    }
    
    private void UpdateShooting() {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) {
        shootTimer = shootInterval;
        ShootHay(); }
    }

    private void ShootHay() 
    {
        SoundManager.Instance.PlayShootClip();
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }

    void Start()
    {
        SetCountText ();
        winText.text = "";
        loseText.text = "";
    }

    void UpdateTexture(){
        
        myRenderer.material.EnableKeyword("_DETAIL_MULX2");
        
        if (hitBySheep){myRenderer.material = hurtMaterial; hitBySheep=false;}
        else{myRenderer.material = sharedMaterial;}
    }
    void Update()
    {
        if(!end){
            UpdateMovement();
            UpdateShooting();
            UpdateTexture();
            SetCountText();
        }
    }
    
    private void Hurt()
    {
        SoundManager.Instance.PlayHurtClip();
        hitBySheep = true;
        hitPoints -= 10;

        Debug.Log(hitPoints);
        if (hitPoints<=0){   
            Destroy(gameObject, gotHayDestroyDelay);
        }
    }

    private void OnTriggerEnter(Collider other){ // 1 
        if (other.CompareTag("Sheep") && !hitBySheep) // 2 
        {
            Destroy(other.gameObject); // 3
            Hurt(); // 4 
        }
    }

    void SetCountText()
	{
		pointsText.text = "Points: " + gamePoints.ToString ();
        lifeText.text = "Life: " + hitPoints.ToString ();

		if (gamePoints >= 10) 
		{
            end=true;
			winText.text = "You Win!";
		}
        else if (hitPoints <= 0) 
		{
            end=true;
			loseText.text = "You Lost!";
		}
	}
}
