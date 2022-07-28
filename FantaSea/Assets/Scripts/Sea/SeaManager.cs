using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SeaManager : MonoBehaviour
{
    public static SeaManager instance;

    public float waveHeight, waveFrequency, waveSpeed;

    //the ocean that follows the player
    public Sea sea;

    Material seaMat;

    Texture2D displacementMap;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);

        sea = FindObjectOfType<Sea>();
    }
    // Start is called before the first frame update
    void Start()
    {
        setVariables();
    }

    void setVariables()
    {
        seaMat = sea.gameObject.GetComponent<Renderer>().sharedMaterial;
        displacementMap = (Texture2D)seaMat.GetTexture("_waveDisp");
    }
   

    public float getWaveHeight(Vector3 position)
    {
        return sea.gameObject.transform.position.y + displacementMap.GetPixelBilinear(position.x * waveFrequency, position.z * waveFrequency + Time.time * waveSpeed).g * waveHeight *sea.gameObject.transform.localScale.x; 
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
