using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject levelEndGo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelEndGo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            levelEndGo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            levelEndGo.SetActive(false);
        }

    }
}
