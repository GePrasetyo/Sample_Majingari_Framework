using UnityEngine;
using Majingari.Framework.World;

public class TestProving : MonoBehaviour
{
    [SerializeField] WorldConfig config;

    private void Start()
    {

        var i = 0;
        Debug.Log("Test : " + i++);
        Debug.Log("Test : " + ++i);



        //ValidateThings();
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
