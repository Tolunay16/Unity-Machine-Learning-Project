using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Integrations.Match3;


public class AgentController : Agent
{


    //pellet veriables
    [SerializeField] private Transform target;

    public int pelletCount;
    public GameObject food;
    [SerializeField] private List<GameObject> spawnedPelletsList = new List<GameObject>();

    //agent veriables
    [SerializeField] private  float moveSpeed = 4f;

    private Rigidbody rb;

    // Environment Variables
    [SerializeField] private Transform environmentLocation;
	 Material envMaterial;
    public GameObject env;
	
	

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
		envMaterial = env.GetComponent<Renderer>().material;      
    }
    public override void OnEpisodeBegin()
    {
        //agent
        // transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0.3f, Random.Range(-4f, 4f));
        //pellet
		CreatePellet();
       // transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0.3f, Random.Range(-4f, 4f));
    }
    private void CreatePellet()
    //The CreatePellet method ensures that pellets are created at a certain minimum distance from each other and from the agent's position. This change aims to randomly spawn pellets and prevent them from overlapping with each other.
    {		
	  if (spawnedPelletsList.Count != 0)
        {

            RemovePellet(spawnedPelletsList);
        }	
	for (int i = 0; i < pelletCount; i++)
        {
		int counter = 0 ;
		bool distanceGood;
		bool alreadyDecremented = false ;     
            //spawning pellet
            GameObject newPellet = Instantiate(food);
            //Make pellet child of the environment
            newPellet.transform.parent = environmentLocation;
            //Give random spawn location
            Vector3 pelletLocation = new Vector3(Random.Range(-4f, 4f), 0.3f, Random.Range(-4f, 4f));
			if (spawnedPelletsList.Count != 0)
            {
                for (int k = 0; k < spawnedPelletsList.Count; k++)
                {
                    if (counter < 10)
                    {

                        distanceGood = CheckOverlap(pelletLocation, spawnedPelletsList[k].transform.localPosition, 5f);
                        if (distanceGood == false)
                        {

                            pelletLocation = new Vector3(UnityEngine.Random.Range(-4f, 4f), 0.3f, UnityEngine.Random.Range(-4f, 4f));
                            k--;
                            alreadyDecremented = true;
                            Debug.Log("Too close to ohter pellet");

                        }

                        distanceGood = CheckOverlap(pelletLocation, transform.localPosition, 5f);
                        if (distanceGood == false)
                        {

                            Debug.Log("Too close to ohter pellet");
                            pelletLocation = new Vector3(UnityEngine.Random.Range(-4f, 4f), 0.3f, UnityEngine.Random.Range(-4f, 4f));
                            if (alreadyDecremented == false)
                            {
                                k--;
                            }
                        }
                        counter++;

                    }
                    else
                    {

                        k = spawnedPelletsList.Count;
                    }

                }




            }
			
			//"spawn" in location
			newPellet.transform.localPosition = pelletLocation;
			//add to list 
			spawnedPelletsList.Add(newPellet);
			Debug.Log("Spawned");
			
}

    }
	
	public List<float> distanceList = new List<float>();
    public List<float> badDistanceList = new List<float>();
	
	
	    public bool CheckOverlap(Vector3 objectWeWantToAvoidOverlapping, Vector3 alreadyExistingObject, float minDistanceWanted)
        //The CheckOverlap function checks the distance between two points and determines if this distance is below a specified value. This ensures that a new pellet is created at a certain minimum distance from other pellets and the agent's position.
    {


        float DistanceBetweenObjects = Vector3.Distance(objectWeWantToAvoidOverlapping, alreadyExistingObject);
        if (minDistanceWanted <= DistanceBetweenObjects)
        {
            distanceList.Add(DistanceBetweenObjects);
            return true;

        }
        badDistanceList.Add(DistanceBetweenObjects);
        return false;
    }
	
	
	
	private void RemovePellet(List<GameObject> toBeDeletedGameObjectList)
    {

        foreach (GameObject i in toBeDeletedGameObjectList)
        {
            Destroy(i.gameObject);
        }
        toBeDeletedGameObjectList.Clear();

    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        //sensor.AddObservation(target.localPosition);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {

        float moveRotate = actions.ContinuousActions[0];
        float moveForward = actions.ContinuousActions[1];
        rb.MovePosition(transform.position + transform.forward * moveForward * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, moveRotate * moveSpeed, 0f, Space.Self);

        /*
             Vector3 velocity = new Vector3(moveX, 0f, moveZ); 

             velocity = velocity.normalized * Time.deltaTime * moveSpeed;

             transform.localPosition += velocity;

             */

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }
    private void OnTriggerEnter(Collider other)
    //The OnTriggerEnter method defines the actions to be performed when the agent collides with a pellet or a wall. If a pellet is collided with, it is removed from the list and destroyed. Additionally, a reward is given and the episode ends after all pellets are collected. If the agent collides with a wall, a negative reward is given and the episode ends.
    {

        if (other.gameObject.tag == "Pellet")
        {
             //remove from list
            spawnedPelletsList.Remove(other.gameObject);
            Destroy(other.gameObject);
            AddReward(10f);
            if (spawnedPelletsList.Count == 0)
            {
			envMaterial.color = Color.green;
                RemovePellet(spawnedPelletsList);
                AddReward(10f);
              
                EndEpisode();


            }
        if (other.gameObject.tag == "Wall")
		
        {
		envMaterial.color = Color.red;
		 RemovePellet(spawnedPelletsList);
            AddReward(-15f);
            EndEpisode();

        }
    }


}