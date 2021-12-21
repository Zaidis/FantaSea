using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Sea : MonoBehaviour
{

    private MeshFilter mf;
    public Boat_Base boat;
    private void Awake()
    {
        mf = GetComponent<MeshFilter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(boat.transform.position.x, 0, boat.transform.position.z), this.transform.rotation);
    }
}
