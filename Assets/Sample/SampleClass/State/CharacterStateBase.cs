using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateBase : StateClassBase {

    protected Character character;

    public CharacterStateBase(Character character)
    {
        this.character = character;
    }
}
