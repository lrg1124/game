using UnityEngine;
using UnityEditor;
using Assets.Src.Editor.Tool;
using Assets.Src.Editor.Tool.Common;
using System;

public class ToolWindow : EditorWindow {

    [MenuItem("MeTool/工具", false)]
    static void OpenWin() {
        var win = GetWindow<ToolWindow>("工具");
        win.minSize = new Vector2(390, 390);
    }

    string[] mTitles;
    ToolPanel[] mPanels;
    int mSelectedIndex = 0;

    void OnEnable() {
        mTitles = new string[] { "常用工具" };
        mPanels = new ToolPanel[] { new CommonToolPanel() };
    }

    void OnGUI() {

        var currPanel = mPanels[mSelectedIndex];
        var newIndex = GUILayout.Toolbar(mSelectedIndex, mTitles, GUILayout.Height(25));
        if (newIndex != mSelectedIndex) {
            currPanel.OnDestroy();
            currPanel = mPanels[newIndex];
            currPanel.OnEnable();
            mSelectedIndex = newIndex;
        }

        try {
            GUILayout.BeginVertical();
            GUILayout.Space(5);
            currPanel.OnGUI();
            GUILayout.EndVertical();
        } catch (InvalidOperationException) {
        } catch (NullReferenceException) {
        } catch (Exception e) {
            Debug.LogException(e);
        }

    }

    void OnDestroy() {
        mPanels[mSelectedIndex].OnDestroy();
    }

}