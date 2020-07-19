using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class House : MonoBehaviour
{
    [SerializeField] private Material materialReplace;
    [SerializeField] private string materialReplaceName;
    
    // Workaround to change all 'black' outlines materials from blender.
    void Awake()
    {
        List<MeshRenderer> meshRenderers = transform.GetComponentsInChildren<MeshRenderer>().ToList();
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.gameObject.layer = LayerMask.NameToLayer("Ground");
            Material[] materials = new Material[meshRenderer.materials.Length]; 
            for(int i = 0; i < meshRenderer.materials.Length; i++)
            {
                if (meshRenderer.materials[i].name.StartsWith(materialReplaceName))
                {
                    materials[i] = materialReplace;
                }
                else
                {
                    materials[i] = meshRenderer.materials[i];
                }
            }
            meshRenderer.materials = materials;
        }

    }

    void Update()
    {
        
    }
}
