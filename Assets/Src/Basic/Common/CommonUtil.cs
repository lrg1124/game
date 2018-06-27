using System.Text;
using UnityEngine;

public static class CommonUtil {

    #region 打印
    public static bool CanDebug { set; get; }

    public static void Debug(this object target, object msg, params object[] param) {
        if (CanDebug) {
            UnityEngine.Debug.Log(msg.ToString(Color.blue, param));
        }
    }

    public static void Error(this object target, object msg, params object[] param) {
        if (CanDebug) {
            UnityEngine.Debug.Log(msg.ToString(Color.red, param));
        }
    }

    public static void Warning(this object target, object msg, params object[] param) {
        if (CanDebug) {
            UnityEngine.Debug.Log(msg.ToString(Color.yellow, param));
        }
    }
    #endregion

    #region 字符串
    /// <summary>
    /// 颜色格式化
    /// </summary>
    /// <param name="self"></param>
    /// <param name="color"></param>
    public static string ToString(this string self, Color color) {
        //<color=#ffffffff>self</color>
        var builder = new StringBuilder();
        builder.Append("<color=#");
        builder.Append(ColorUtility.ToHtmlStringRGBA(color));
        builder.Append(">");
        builder.Append(self);
        builder.Append("</color>");
        return builder.ToString();
    }

    /// <summary>
    /// 参数格式化
    /// </summary>
    /// <param name="target"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public static string ToString(this object target, params object[] param) {
        return string.Format(target.ToString(), param);
    }

    public static string ToString(this object target, Color color, params object[] param) {
        return string.Format(target.ToString(), param).ToString(color);
    }
    #endregion
}
