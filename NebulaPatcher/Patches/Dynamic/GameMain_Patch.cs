﻿using HarmonyLib;

namespace NebulaPatcher.Patches.Dynamic
{
    [HarmonyPatch(typeof(GameMain))]
    class GameMain_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Pause")]
        public static bool Pause_Prefix()
        {
            // TODO: We cannot really do that since it will prevent the Esc Menu from opening and the
            // players won't be able to exit the game or change their game settings. We should instead
            // Wopen the menu, but unpause the game under the hood.
            return true;

            //Do not pause game in the multiplayer
            //Pausing game has to be done via: GameMain.instance._paused = true;
            //return !SimulatedWorld.Initialized;
        }
    }
}
