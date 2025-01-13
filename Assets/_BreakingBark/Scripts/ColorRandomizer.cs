using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{

    public Color[] Colors;
    public List<Material> SelectedMats; // In Editor, it must be equal 0 !!
    public int[] ChoosedIndex;

    MeshRenderer Mesh;
    Material[] BasedMat;
    Material[] NewMat;


    // Start is called before the first frame update
    void Start()
    {
        
        ChangedColoring();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ChangedColoring ()
    {
        Mesh = GetComponent<MeshRenderer>();
        BasedMat = new Material[Mesh.materials.Length];
        SelectedMats = new List<Material>(0);

        // copy based materials and put it on an array
        for (int i =0; i < Mesh.materials.Length; i++)
        {
            BasedMat[i] = Mesh.materials[i];
        }

        NewMat = BasedMat;



        // paste new
            for (int n = 0; n < ChoosedIndex.Length; n++)
            {
                Material Mat = new Material(BasedMat[ChoosedIndex[n]]);
                SelectedMats.Add(Mat);
                NewMat[ChoosedIndex[n]] = Mat;
            }    
    
        // change color
        for (int i = 0; i < SelectedMats.Count; i++)
        {
            int Colo = Random.Range(0, Colors.Length - 1);
            SelectedMats[i].color = Colors[Colo];
            SelectedMats[i].name = "ChangedMat_" + Colors[Colo].ToString();
        }

        Mesh.materials = NewMat;
    }



}
