using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    // not entirely sure why i would want these variables?
    // they could be usefull but i already have _numSeeds
    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        // id rather use getComponent for the transform
        _playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        // move the player
        MoveFromAxis();

        // plant a seed if the player pressed space and there are seeds left
        if (_numSeeds > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            // spawn plant prefab
            GameObject plant = Instantiate(_plantPrefab);

            // move plant prefab to player location
            plant.transform.position = _playerTransform.position;
        }
    }

    /// <summary>
    /// plants a seed prefab at the player location.
    /// </summary>
    public void PlantSeed ()
    {
        
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
