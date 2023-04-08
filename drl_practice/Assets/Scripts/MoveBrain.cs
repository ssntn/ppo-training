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
    private float episodeTimeLimit = 400.0f;
    public float TimeElapsed { get; private set; }
    public float CurrentStep { get; private set; }
    private float attackProc = 0f;

    private void Start()
    {
        p = gameObject.GetComponent<PlayerController>();
        CurrentStep = 0;
        // transform.localPosition = gm.RandomPos();
        // coin.localPosition = gm.RandomPos();
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = GameManager.instance.RandomPos();
        coin.localPosition = GameManager.instance.RandomPos();
        TimeElapsed = 0.0f;   
    }

    public override void CollectObservations(VectorSensor sensor)
    {

        sensor.AddObservation(transform.localPosition); // 3 observations
        sensor.AddObservation(coin.localPosition); // 3 observations

        // 7th obs
        attackProc = Random.Range(0,1);
        sensor.AddObservation(attackProc); 

        float randomOffset = Random.Range(-1f,1f);
        sensor.AddObservation(randomOffset);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        inputX = actions.ContinuousActions[0];
        inputY = actions.ContinuousActions[1];

        p.Move(inputX, inputY);

        // vectorSub = get angle from player coord to enemy coord 
        // offset = random offset using distance
        // p.Shoot(vectorSub, offset);

        // AddReward(-0.1f);
        TimeElapsed += Time.deltaTime;

        if (TimeElapsed >= episodeTimeLimit) {
            SetReward(-1f);
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        /*  
            DAs
                (3): player position
                (3): enemy position
                (1): mouse (3): pe vector sub 3 * 3[] - 1[i]

        */

        ActionSegment<float> ca = actionsOut.ContinuousActions;
        ca[0] = Input.GetAxisRaw("Horizontal");
        ca[1] = Input.GetAxisRaw("Vertical");
        ca[6] = Input.GetMouseButton(0) ? 1f : 0f;

        p.Move(ca[0], ca[1]);
        if(ca[6] == 1)  p.Shoot(1f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            SetReward(5f);
        }else if (other.tag == "Block")
        {
            SetReward(-1f);
        }

        EndEpisode();
    }

    public void CoinHit(){
        SetReward(8f);
        EndEpisode();
    }
}
