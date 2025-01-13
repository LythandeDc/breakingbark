using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[ExecuteInEditMode]
public class MaterialAdapter : MonoBehaviour
{
    MeshRenderer Mesh;
    [Tooltip("Only 1 material")] public Material Mater;
    [Tooltip("Only 1 material")] public Material NewMater;
    [Header("Modifs")]
    public Color Coloring;
    public bool AffectChange;


    /// <summary>
    /// not used
    /// </summary>
    [Tooltip("Newmat - range")] [Range(0, 1)] public float RangerR;
    [Tooltip("Newmat - range")] [Range(0, 1)] public float RangerG;
    [Tooltip("Newmat - range")] [Range(0, 1)] public float RangerB;
    [Tooltip("Newmat - range")] [Range(0, 1)] public float RangerA = 0;









    // Start is called before the first frame update
    void Start()
    {

        GetStats();
    }



    void GetStats ()
    {
        if (Application.isPlaying == false)
        {
                Mesh = GetComponent<MeshRenderer>();
                Mater = Mesh.sharedMaterial;
                Material M = Mater;
                NewMater = new Material(Mater);
                NewMater.name += "(Copy)";
                Coloring = NewMater.color;
                // Mesh.material = new Material(Mater);
        }
    }


    void Adaptation ()
    {
        if (AffectChange)
        {
            NewMater.color = Coloring;
            Mesh.material = NewMater;
            // NewMater.color = new Color(RangerR, RangerG, RangerB,  RangerA);
            //  NewMater.color = new Color(NewMater.color.r - RangerR, NewMater.color.g - RangerG, NewMater.color.b - RangerB, NewMater.color.a - RangerA);
        }
        else
        {
            Mesh.material = Mater;
        }
    }







    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying == false)
        {
            if (NewMater != null)
            {
                Adaptation();





            }
        }
    }


     







}
