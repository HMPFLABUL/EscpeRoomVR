using UnityEngine;
using System.Collections;

public static class DataPlayer {

    public static float playerHeight = 1.6f;
    public static StandingPoints playerActPoint = StandingPoints.MainDoors;

    public enum StandingPoints
    {
        MainDoors, Desks, Projector, BossDoors, Hamster, BossWall

    }
}
