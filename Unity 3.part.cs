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
    private Rigidbody rb;
    ////A Rigidbody component named rb has been added. This component assists in calculating physical interactions and the movement of the agent.
    // Environment Variables
  
    public override void Initialize()
    //This function is called when the agent is initialized and retrieves the Rigidbody component.
    {
        
        rb = GetComponent<Rigidbody>();    
    }
    public override void OnEpisodeBegin()
    {
        //agent
         transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0.3f, Random.Range(-4f, 4f));
        //pellet
        transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0.3f, Random.Range(-4f, 4f));
    }
    public override void CollectObservations(VectorSensor sensor)
    //The process of collecting the target's position has been removed because the target's position is no longer used.
    {
        sensor.AddObservation(transform.localPosition);
        //sensor.AddObservation(target.localPosition);
    }
    public override void OnActionReceived(ActionBuffers actions)
    //This function now supports two-dimensional movement. The agent uses rb.MovePosition() to move forward, while rotation is handled with transform.Rotate(). This provides more stable movement and turning.

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
    //When the agent collides with a pellet object, the reward received by the agent is now set to 5 units.
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