using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//Скрипт нужен для удобного изменения параметров маски для всей сцены
[CreateAssetMenu(fileName = "MaskProperties", menuName = "let-down-some-pigeons/MaskProperties", order = 0)]
public class MaskProperties : ScriptableObject { 
    public Color MaskColor; /*Прозрачность*/
    public Vector3 Scale;
}

