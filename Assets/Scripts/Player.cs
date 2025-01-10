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

    // not entirely sure why i would want these variables?
    // they could be usefull but i already have _numSeeds
    private int _numSeedsPlanted;

    private void Start ()
    {
        // id rather use getComponent for the transform
        _playerTransform = GetComponent<Transform>();

        // have player seed count match start count
        _numSeedsLeft = _numSeeds;

        // call ui update so it has the right values
        _plantCountUI.UpdateSeeds(_numSeedsLeft, 0);
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
            GameObject plant = Instantiate(_plantPrefab);

            // move plant prefab to player location
            plant.transform.position = _playerTransform.position;

            // update the seed counter
            _numSeedsLeft -= 1;

            // update ui (i use _num seeds - _numSeeds left for Seeds Remaining)
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeeds - _numSeedsLeft);
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
