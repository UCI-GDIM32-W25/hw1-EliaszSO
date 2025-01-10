using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        
    }

    private void Update()
    {
        // move the player
        MoveFromAxis();
    }

    public void PlantSeed ()
    {
        
    }

    
    private void MoveFromAxis()
    {
        // i like to use the axis floats for movement becayse they let me use the arrow keys 
        // and WASD with less code overall

        // get axis float values from unity event system
        float horizontalFloat = Input.GetAxisRaw("Horizontal");
        float verticalFloat = Input.GetAxisRaw("Vertical");

        // make a vector 2 from the floats denoting the move direction
        Vector2 moveDirection = new Vector2(horizontalFloat, verticalFloat);

        //transform the player by the move direction * speed fixed with deltatime
        _playerTransform.Translate(moveDirection * _speed * Time.deltaTime);

    }
}
