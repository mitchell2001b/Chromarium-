using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new DestructableObject", menuName = "Destructable")]
public class DestructableObject : ScriptableObject
{
    public DestructableTypes.DestructableObjectType ObjectType;
}
