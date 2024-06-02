using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using static UnityEngine.GraphicsBuffer;

public class AgentController : Agent
{
    [SerializeField] private Transform target;
    public override void OnEpisodeBegin()
    //This function is called at the beginning of the training episode. It randomly sets the agent's starting position and the target's location.
    {
        transform.localPosition = new Vector3(0f, 0.3f, 0f);
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            target.localPosition = new Vector3(-4f, 0.3f, 0f);
        }
        if (rand == 1)
        {
            target.localPosition = new Vector3(4f, 0.3f, 0f);
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
     //This function collects observations. In this context, the positions of both the agent and the target are added to the observations.
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(target.localPosition);
    }
    public override void OnActionReceived(ActionBuffers actions)
    //This function is called when the agent receives an action. In this scenario, the agent receives an action that enables it to move horizontally, and the agent executes this action.
    {
        float move = actions.ContinuousActions[0];
        float moveSpeed = 2f;

        transform.localPosition += new Vector3(move, 0f) * Time.deltaTime * moveSpeed;
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //This function is called when the agent's actions are controlled by a human. In other words, if the agent is under human control, it allows the agent to move according to keyboard inputs.
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
    }
    private void OnTriggerEnter(Collider other)
    //This function is called when the agent enters a trigger zone (e.g., a pellet or a wall). If the agent collides with a pellet (food) object, it receives a reward and the episode ends. If it collides with a wall, it receives a penalty and the episode ends.
    {

        if (other.gameObject.tag == "Pellet")
        {
            AddReward(2f);
            EndEpisode();

        }
        if (other.gameObject.tag == "Wall")
        {
            AddReward(-1f);
            EndEpisode();

        }
        }


    }