using UnityEngine;
using UnityEditor;
using Assets.Src.Editor.Tool;
using Assets.Src.Editor.Tool.Common;

public class ToolWindow : EditorWindow {

    [MenuItem("MeTool/工具", false)]
    static void OpenWin() {
        var win = GetWindow<ToolWindow>("工具");
        win.minSize = new Vector2(390, 10);
    }

    ToolPanel[] mPanels;
    int mSelectedIndex = 0;

    void OnEnable() {
        mPanels = new ToolPanel[] { new CommonToolPanel(),};
    }

    void OnGUI() {

        if (mPanels.Length > 0) {

            var currPanel = mPanels[mSelectedIndex];
            var newIndex = GUILayout.Toolbar(mLastTabIndex, mPanels.Stream().Map(i => i.Title).ToArray(), GUILayout.Height(25));
            if (newIndex != mLastTabIndex) {
                currPanel.OnDestroy();
                currPanel = mPanels[newIndex];
                currPanel.OnEnable();
                mLastTabIndex = newIndex;
                ToolkitSettings.Ins.Set(ToolkitSettingKeys.LAST_TAB_INDEX_KEY, mLastTabIndex);
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

        if (GUI.changed) {
            ToolkitSettings.Ins.Save();
        }

    }


    void OnDestroy() {
        mPanels[mLastTabIndex].OnDestroy();
    }

}