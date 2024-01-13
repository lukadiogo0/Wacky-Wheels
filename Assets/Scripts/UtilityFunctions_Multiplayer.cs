﻿using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class UtilityFunctions_Multiplayer : NetworkBehaviour
{
    public void SetDrifting()
    {
        if (!IsOwner) return;
        transform.parent.GetComponent<KartController_Multiplayer>().isSliding = true;
    }
}
