using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    // the max seeds that the player starts out with
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    // the number of seeds the player has on them
    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        // id rather use getComponent for the transform
        _playerTransform = GetComponent<Transform>();

        // have player seed count match start count
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;

        // call ui update so it has the right values
        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
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
    }

    /// <summary>
    /// plants a seed prefab at the player location.
    /// </summary>
    public void PlantSeed ()
    {
            // spawn plant prefab
            GameObject plantObject = Instantiate(_plantPrefab, transform.position, Quaternion.identity);

            // make the plant reference this player
            Plant plant = plantObject.GetComponent<Plant>();
            plant.player = this;

            // update the seed counters
            _numSeedsLeft--;
            _numSeedsPlanted++;

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
        // the player z is linked to its y
        Vector3 moveDirection = new Vector3(horizontalFloat, verticalFloat, verticalFloat);
        moveDirection = moveDirection.normalized;

        //transform the player by the move direction * speed fixed with deltatime
        _playerTransform.Translate(moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Seed!");
        // do seed actions when interacting with a seed
        if (other.tag == "Seed")
        {
            // get a seed
            _numSeedsLeft++;

            // delete seed
            Seed seed = other.GetComponent<Seed>();
            seed.PickupSeed();
        }
    }
}
