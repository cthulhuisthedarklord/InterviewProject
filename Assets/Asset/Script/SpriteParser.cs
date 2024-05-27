using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteParser : MonoBehaviour
{
    [SerializeField] public Sprite[] A = new Sprite[25];
    public static Dictionary<int, string> alphabetMap = new Dictionary<int, string>();
    public static SpriteParser instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        alphabetMap.Add(0, "a");
        alphabetMap.Add(1, "b");
        alphabetMap.Add(2, "c");
        alphabetMap.Add(3, "d");
        alphabetMap.Add(4, "e");
        alphabetMap.Add(5, "f");
        alphabetMap.Add(6, "g");
        alphabetMap.Add(7, "h");
        alphabetMap.Add(8, "i");
        alphabetMap.Add(9, "j");
        alphabetMap.Add(10, "k");
        alphabetMap.Add(11, "l");
        alphabetMap.Add(12, "m");
        alphabetMap.Add(13, "n");
        alphabetMap.Add(14, "o");
        alphabetMap.Add(15, "p");
        alphabetMap.Add(16, "q");
        alphabetMap.Add(17, "r");
    }
    public Sprite SpriteParse(string str)
    {
        switch (str)
        {
            case "a":
                return A[0];
            case "b":
                return A[1];
            case "c":
                return A[2];
            case "d":
                return A[3];
            case "e":
                return A[4];
            case "f":
                return A[5];
            case "g":
                return A[6];
            case "h":
                return A[7];
            case "i":
                return A[8];
            case "j":
                return A[9];
            case "k":
                return A[10];
            case "l":
                return A[11];
            case "m":
                return A[12];
            case "n":
                return A[13];
            case "o":
                return A[14];
            case "p":
                return A[15];
            case "q":
                return A[16];
            case "r":
                return A[17];
            case "s":
                return A[18];
            case "t":
                return A[19];
            case "u":
                return A[20];
            case "v":
                return A[21];
            case "w":
                return A[22];
            case "x":
                return A[23];
            case "y":
                return A[24];
            case "z":
                return A[25];
            default:
                return null;
        }
    }
}
