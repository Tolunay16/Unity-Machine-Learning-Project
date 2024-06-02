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
       // transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0.3f, Random.Range(-4f, 4f));
    }
    private void CreatePellet()
    //This function ensures the pellets are recreated at the start of each episode. It is used to reset and reposition the pellets when the game restarts.
    {		
	  if (spawnedPelletsList.Count != 0)
        {
            RemovePellet(spawnedPelletsList);
        }
	for (int i = 0; i < pelletCount; i++)
        {   
            //spawning pellet
            GameObject newPellet = Instantiate(food);
            //Make pellet child of the environment
            newPellet.transform.parent = environmentLocation;
            //Give random spawn location
            Vector3 pelletLocation = new Vector3(Random.Range(-4f, 4f), 0.3f, Random.Range(-4f, 4f));
			//"spawn" in location
			newPellet.transform.localPosition = pelletLocation;
			//add to list 
			spawnedPelletsList.Add(newPellet);
			Debug.Log("Spawned");		
    }	
	private void RemovePellet(List<GameObject> toBeDeletedGameObjectList)
    //This function removes specified pellet objects from the list and clears the list. It is used when the pellets need to be destroyed.
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
    //If the agent collides with a pellet, the pellet is removed from the list, and a reward is given. If this collision results in the pellet list being emptied, the environment color changes to green, and the game is completed. If the agent collides with a wall, the environment color changes to red, and the agent is penalized.
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