using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveBrain : Agent
{
    PlayerController p;
    private float inputX, inputY;
    Vector3 posCam;

    [SerializeField]
    private Transform coin;

    [SerializeField]
    private GameManager gm;

    [SerializeField]
    private float episodeTimeLimit = 5.0f;
    private float timeElapsed = 0.0f;

    private void Start()
    {
        p = gameObject.GetComponent<PlayerController>();
        timeElapsed = 0.0f;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = gm.RandomPos();
        gm.CoinRandomPos();
        timeElapsed = 0.0f;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(coin.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        inputX = actions.ContinuousActions[0];
        inputY = actions.ContinuousActions[1];
        
        p.Move(inputX, inputY);

        AddReward(-0.1f);
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= episodeTimeLimit) {
            SetReward(-1f);
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> da = actionsOut.ContinuousActions;
        da[0] = Input.GetAxisRaw("Horizontal");
        da[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            SetReward(2f);
            Debug.Log("coined");
        }
        if (other.tag == "Block")
        {
            SetReward(-1f);
            Debug.Log("blocked");
        }

        EndEpisode();
    }
}
