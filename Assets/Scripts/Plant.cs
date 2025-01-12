using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private float _tickTimer;
    [SerializeField] private float _ticksPerSecond = 2;
    private float _timePerTick;
    
    // the probability the plant will grow every tick
    [SerializeField] private float _growChance;
    private Animator _plantAnimator;
    private SpriteRenderer _plantRenderer;

    // represents how old the plant is (appearance and patiencePoints)
    private int _growthStage;

    [HideInInspector] public Player player;
    

    void Start()
    {
        //setup timer and tick values
        _tickTimer = 0f;
        _timePerTick = 1 / _ticksPerSecond;

        //get animator and renderer components
        _plantAnimator = GetComponent<Animator>();
        _plantRenderer = GetComponent<SpriteRenderer>();

        _growthStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //growth by tick system:
        //increase timer by the amount of time that has passed
        _tickTimer += Time.deltaTime;

        // if timer is greater than time per tick a tick should have been triggered
        if (_tickTimer >= _timePerTick)
        {
            TickEvent();

            //reset timer (discounting error amount)
            _tickTimer -= _timePerTick;
        }
    }

    private void AppearBeforeBehind()
    {
        // appear in front/ behind player
        bool playerInFrontOfPlant = player.transform.position.y < transform.position.y;
        if (playerInFrontOfPlant)
        {
            _plantRenderer.sortingOrder = 4;
        }
        else
        {
            _plantRenderer.sortingOrder = 6;
        }
    }

    /// <summary>
    /// triggered on ever tick for this game object
    /// </summary>
    private void TickEvent()
    {
        //try to grow the plant
        float randomValue = Random.Range(0f, 1f);
        
        if (randomValue < _growChance)
        {
            
            if (_growthStage < 6)
            {
                GrowPlant();
            }
            else if (_growthStage < 7)
            {
                // when the plant is fully grown
                player.patienceScore++;
            }
        }

    }

    public void GrowPlant()
    {
        // increase the growth stage
        _growthStage +=1;

        // cause the animation to change
        _plantAnimator.SetInteger("GrowthLevel", _growthStage);
    }
}
