using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Creature{
    Guppy,
    Guppy2,
    Guppy3,
    Neon, //
    PinkNeon,
    AngelFish,
    DragonFish,
    ElectriclEel, // 
    Shark,
    BlueDragonFish,
    GreatWhiteShark,
    KillerWhale, // 
}
public class Level
{
    public string name;
    public int requiredScore;
    public Creature specialCreature;
    public Level(string name, int requiredScore, Creature specialCreature){
        this.name = name;
        this.requiredScore = requiredScore;
        this.specialCreature = specialCreature;
    } 
}
