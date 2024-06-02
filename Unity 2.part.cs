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
    //agent veriables
    [SerializeField] private  float moveSpeed = 4f;
    // Environment Variables
    public override void OnEpisodeBegin()
    //This function now ensures that both the agent and the target are placed at random positions at the start of each episode. This allows the training process to occur in different locations and scenarios.
    {
        //agent
         transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0.3f, Random.Range(-4f, 4f));


        //pellet
        transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0.3f, Random.Range(-4f, 4f));
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(target.localPosition);
    }
    public override void OnActionReceived(ActionBuffers actions)
//This function now takes two-dimensional movement (along the x and z axes). It uses the received action to move the agent along the x and z axes.
    {

        float movex = actions.ContinuousActions[0];
        float moveY= actions.ContinuousActions[1];
             Vector3 velocity = new Vector3(moveX, 0f, moveZ); 
             velocity = velocity.normalized * Time.deltaTime * moveSpeed;
             transform.localPosition += velocity;         
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    //To capture keyboard inputs for two-dimensional movement, Input.GetAxisRaw("Horizontal") and Input.GetAxisRaw("Vertical") are used.
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }
    private void OnTriggerEnter(Collider other)
    //When the agent collides with a pellet object, the reward is now set to 5 units. Additionally, if the collision is with a wall, the agent receives a penalty, and the episode ends.
    {
        if (other.gameObject.tag == "Pellet")
        {                                 
                AddReward(5f);
                
                EndEpisode();
            }
        if (other.gameObject.tag == "Wall")
        {
            AddReward(-1f);
            EndEpisode();
        }
    }
}