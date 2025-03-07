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
    ElectriclEel, 
    Shark,
    BlueDragonFish,
    GreatWhiteShark,
    KillerWhale, // 
}
public class Level
{
    public string name;
    public int requiredLevel, initLevel;
    public Creature specialCreature;
    public Level(string name, int requiredScore, Creature specialCreature, int initLevel){
        this.name = name;
        this.requiredLevel = requiredScore;
        this.initLevel = initLevel;
        this.specialCreature = specialCreature;
    } 
}
