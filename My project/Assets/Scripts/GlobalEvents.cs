using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void IntEvent(int _);
public delegate void VoidEvent();

public static class GlobalEvents {
    public static class UI {
        public static IntEvent UpdateHealthBarEvent;
        public static IntEvent UpdateCoinCountEvent;
    }
}