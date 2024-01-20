using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void IntEvent(int _);
public delegate void VoidEvent();
public delegate void FloatEvent(float _);

public static class GlobalEvents {
    public static class UI {
        public static FloatEvent UpdateHealthBarEvent;
        public static IntEvent UpdateCoinCountEvent;
    }

    public static class Player {
        public static VoidEvent PlayerDeathEvent;
        public static VoidEvent PlayerRepositionEvent;
    }
}