using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveBrain : Agent
{
    PlayerController p;
    private float inputX;
    private float inputY;
    Vector3 posCam;

    [SerializeField]
    private Transform coin;
    [SerializeField]
    private GameManager gm;

    private void Start()
    {
        p = gameObject.GetComponent<PlayerController>();

        //posCam = Camera.main.WorldToViewportPoint(transform.position);
        //if (posCam.x < 0f || posCam.x > 1f || posCam.y < 0f || posCam.y > 1f)
        //    s_player = STATE.BLOCKED;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = gm.RandomPos();
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
            SetReward(1f);
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
