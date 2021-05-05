using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;

    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    public HayMachine machine;
    private SheepSpawner sheepSpawner;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
        runSpeed = Random.Range(5,20);
    }

    // Update is called once per frame
    void Update()
    {
        if(!machine.end){
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        }
    }

    private void HitByHay()
    {
        SoundManager.Instance.PlaySheepHitClip();
        hitByHay = true; // 1
        runSpeed = 0; // 2  
        transform.Rotate(0,0,90.0f);
        transform.Translate(1,0,0);
        Destroy(gameObject, gotHayDestroyDelay); // 3
        machine.gamePoints+=1;
    }

    private void Drop()
    {
        SoundManager.Instance.PlaySheepDroppedClip();
        myRigidbody.isKinematic = false; // 1
        myCollider.isTrigger = false; // 2  
        Destroy(gameObject, dropDestroyDelay); // 3
        machine.gamePoints-=1;
    }

    private void OnTriggerEnter(Collider other){ // 1 
        if (other.CompareTag("Hay") && !hitByHay) // 2 
        {
            sheepSpawner.RemoveSheepFromList(gameObject);
            Destroy(other.gameObject); // 3
            HitByHay(); // 4 
        }
        else if (other.CompareTag("DropSheep"))
        {
            sheepSpawner.RemoveSheepFromList(gameObject);
            Drop();
        }
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}
