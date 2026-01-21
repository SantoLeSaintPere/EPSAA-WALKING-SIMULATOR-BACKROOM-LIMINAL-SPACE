using UnityEngine;

public class PlayerFpsInputReader : MonoBehaviour
{
    [HideInInspector]
    public GameInputControls inputControls;

    [HideInInspector]
    public Vector3 direction;
    //[HideInInspector]
    public bool isMoving;
    [HideInInspector]
    public float lookX;
    [HideInInspector]
    public float lookY;
    private void Awake()
    {
        inputControls = new GameInputControls();
    }

    private void OnEnable()
    {
        inputControls.PLAYER.Enable();
    }

    private void OnDisable()
    {
        inputControls.PLAYER.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = inputControls.PLAYER.MOVE.ReadValue<Vector2>();
        direction = new Vector3(dir.x, 0, dir.y);

        isMoving = inputControls.PLAYER.MOVE.ReadValue<Vector2>().sqrMagnitude != 0;

        lookX = inputControls.PLAYER.LOOKX.ReadValue<float>();
        lookY = inputControls.PLAYER.LOOKY.ReadValue<float>();


        if(inputControls.PLAYER.QUIT.WasPerformedThisFrame())
        {
            Application.Quit();
        }
    }
}
