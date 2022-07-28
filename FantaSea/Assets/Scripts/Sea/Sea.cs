using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Sea : MonoBehaviour
{

    private MeshFilter mf;
    //public Boat_Base boat;
    [SerializeField] private Transform m_currentTarget;
    private void Awake()
    {
        m_currentTarget = FindObjectOfType<Boat_Base>().transform;
        mf = GetComponent<MeshFilter>();
    }
    
    /// <summary>
    /// Changes target for the ocean to follow. 
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeTarget(GameObject obj) {
        m_currentTarget = obj.transform;
    }
    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(m_currentTarget.transform.position.x, 0, m_currentTarget.transform.position.z), this.transform.rotation);
    }
}
