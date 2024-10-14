
using UnityEngine;
using Unity.AI.Navigation;

public class StartGame : MonoBehaviour
{
    void Update ()
    {
    }
    
    [SerializeField] private NavMeshSurface surface;
    private float span;
    public void Build()
    {

    }
    void Start()
    {
      Invoke("Build2",60f);
    }
}
