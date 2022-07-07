using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;
    public float speedMultipier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateSpike();
    }

    

    public void generateSpike()
    {
        GameObject SpikeIns =  Instantiate(spike, transform.position, transform.rotation);

        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
    }

    private void Update()
    {
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += speedMultipier;
        }
    }

}
