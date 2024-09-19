
using UnityEngine;
using Unity.AI.Navigation;

public class StartGame : MonoBehaviour
{
    void Update ()
    {
         if (Input.GetKey(KeyCode.A))
           Build();
    }
    
    [SerializeField] private NavMeshSurface surface;
    public void Build()
    {
        surface.BuildNavMesh();
    }
}
