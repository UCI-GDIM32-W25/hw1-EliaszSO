using UnityEditor.Search;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    // the max seeds that the player starts out with
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    // the number of seeds the player has on them
    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    [HideInInspector] public int patienceScore;
    private bool _learnedPatience;
    [SerializeField] private GameObject _patienceScreen;

    private void Start ()
    {
        // id rather use getComponent for the transform
        _playerTransform = GetComponent<Transform>();

        // have player seed count match start count
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;

        // call ui update so it has the right values
        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);

        // player does not yet know patience
        _learnedPatience = false;
        _patienceScreen.SetActive(false);
    }

    private void Update()
    {
        // move the player
        MoveFromAxis();

        // plant a seed if the player pressed space and there are seeds left
        if (_numSeedsLeft > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            PlantSeed();
        }

        // patience end screen
        if (patienceScore >= 1 && patienceScore == _numSeedsPlanted && !_learnedPatience)
        {
            // player has learned patience
            _learnedPatience = true;

            // show patience screen
            _patienceScreen.SetActive(true);
        }
    }

    /// <summary>
    /// plants a seed prefab at the player location.
    /// </summary>
    public void PlantSeed ()
    {
            // spawn plant prefab
            GameObject plantObject = Instantiate(_plantPrefab);

            // move plant prefab to player location
            plantObject.transform.position = _playerTransform.position;

            // make the plant reference this player
            Plant plant = plantObject.GetComponent<Plant>();
            plant.player = this;

            // update the seed counters
            _numSeedsLeft -= 1;
            _numSeedsPlanted += 1;

            // update ui with new counts
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }
    
    /// <summary>
    /// translates the player based on input axis floats.
    /// </summary>
    private void MoveFromAxis()
    {
        // i like to use the axis floats for movement becayse they let me use the arrow keys 
        // and WASD with less code overall

        // get axis float values from unity event system
        float horizontalFloat = Input.GetAxisRaw("Horizontal");
        float verticalFloat = Input.GetAxisRaw("Vertical");

        // make a vector 2 from the floats denoting the move direction
        // make it normal for consistant movement speed
        Vector2 moveDirection = new Vector2(horizontalFloat, verticalFloat);
        moveDirection = moveDirection.normalized;

        //transform the player by the move direction * speed fixed with deltatime
        _playerTransform.Translate(moveDirection * _speed * Time.deltaTime);
    }
}
