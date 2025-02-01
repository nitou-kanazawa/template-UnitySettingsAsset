#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;

namespace Demo.Settings {

    /// <summary>
    /// Editorで参照するプロジェクト固有の設定データ．
    /// </summary>
    [FilePath(
        relativePath: "ProjectSettings/MyProjectEditorSettings.dat",
        location: FilePathAttribute.Location.ProjectFolder
    )]
    public class ProjectEditorSettingsSO : ScriptableSingleton<ProjectEditorSettingsSO> {

        [SerializeField] 
        private EditorSettingsData _data;

        public EditorSettingsData Data => _data;

        public void Save() => Save(true);
    }


    [Serializable]
    public struct EditorSettingsData {
        public int num1;
        public int num2;
    }
}
#endif