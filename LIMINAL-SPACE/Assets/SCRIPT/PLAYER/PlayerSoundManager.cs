using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    PlayerFpsInputReader inputReader;
    public GameObject audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputReader = GetComponent<PlayerFpsInputReader>();
        audio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        audio.SetActive(inputReader.isMoving);
    }
}
