using UnityEngine;
using System.Collections;

public class itemFood : itemAbstract {

    public int regenerateHunger = 20;

    public override bool execute(playerStatistics pS)
    {
        pS.currentHunger = (pS.currentHunger + regenerateHunger);
        return disposable;
    }
}
