using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guess : MonoBehaviour {

    // Use this for initialization
    void Start() {
        XLua.LuaEnv luaenv = new XLua.LuaEnv();
        luaenv.DoString("CS.UnityEngine.Debug.Log('hello world')");
        luaenv.Dispose();
    }

    // Update is called once per frame
    void Update() {

    }

    /// <summary>
    /// 猴子吃桃，单数扔掉一个
    /// </summary>
    int Eat(int num) {
        int temp = 0;
        while (num > 0) {
            if (num % 2 == 1) {
                temp++;
            }
            num = num / 2;
        }
        return temp;
    }

}
