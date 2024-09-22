
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

    }
    void Start()
    {
          Invoke("Build2",60f);
    }
    private void Build2()
    {
      surface.BuildNavMesh();
    }
}
