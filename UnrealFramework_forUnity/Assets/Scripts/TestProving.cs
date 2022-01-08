using UnityEngine;
using Majingari.Framework.World;

public class TestProving : MonoBehaviour
{
    [SerializeField] WorldConfig config;

    private void Start()
    {
        ValidateThings();
    }

    public void ValidateThings()
    {
        Test1();
    }

    void Test1()
    {
        //Debug.Log(config.Map.name);
    }
}
