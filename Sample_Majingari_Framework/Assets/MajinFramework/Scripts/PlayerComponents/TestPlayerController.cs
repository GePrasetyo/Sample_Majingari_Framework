using UnityEngine;
using Majingari.Framework.World;

public class TestPlayerController : PlayerController
{
    public TestPlayerPawn pawn;
    public TestPlayerState state;

    private void Start() {
        if(GetPawn(out pawn)) {
            Debug.Log("Get Pawn Success");
        }

        if (GetState(out state)) {
            Debug.Log("Get State Success");
        }
    }
}
