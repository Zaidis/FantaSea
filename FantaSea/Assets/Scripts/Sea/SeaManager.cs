using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SeaManager : MonoBehaviour
{
    public static SeaManager instance;

    public float waveHeight, waveFrequency, waveSpeed;

    public GameObject sea;

    Material seaMat;

    Texture2D displacementMap;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        setVariables();
    }

    void setVariables()
    {
        seaMat = sea.GetComponent<Renderer>().sharedMaterial;
        displacementMap = (Texture2D)seaMat.GetTexture("_waveDisp");
    }
    // Update is called once per frame
    void Update()
    {
     
    }

    public float getWaveHeight(Vector3 position)
    {
        return sea.transform.position.y + displacementMap.GetPixelBilinear(position.x * waveFrequency, position.z * waveFrequency + Time.time * waveSpeed).g * waveHeight *sea.transform.localScale.x; 
    }

    private void OnValidate()
    {
        //if no material, set material
        if (!seaMat)
        
            setVariables();

            updateMaterial();
        
    }

    void updateMaterial()
    {
        seaMat.SetFloat("_waveFrequency", waveFrequency);
        seaMat.SetFloat("_waveSpeed", waveSpeed);
        seaMat.SetFloat("_waveSize", waveHeight);
    }
}
