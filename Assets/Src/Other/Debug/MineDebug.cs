using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class MineDebug {

    public static bool LogEnable { set; get; }

    public static void Debug(this object target, object msg, params object[] param) {

    }

    public static void Error(this object target, object msg, params object[] param) {

    }

    public static void Warning(this object target, object msg, params object[] param) {

    }
}
