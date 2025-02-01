using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

// [REF]
//  qiita: Unityで独自の設定のUIを提供できるSettingsProviderの紹介と設定ファイルの保存について https://qiita.com/sune2/items/a88cdee6e9a86652137c

namespace Demo.Settings {

    internal sealed class ProjectSettingsProvider : SettingsProvider {

        private Editor _editor;


        /// ----------------------------------------------------------------------------
        // Public Method

        public ProjectSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords)
            : base(path, scopes, keywords) { }

        public override void OnActivate(string searchContext, VisualElement rootElement) {
            Editor.CreateCachedEditor(ProjectSettingsSO.Instance, null, ref _editor);
        }

        public override void OnGUI(string searchContext) {

            var instance = ProjectSettingsSO.Instance;
            if (instance == null) {
                if (GUILayout.Button("生成する")) {
                    CreateSettings();
                    Editor.CreateCachedEditor(ProjectSettingsSO.Instance, null, ref _editor);
                }
            }

            if (instance != null) {
                _editor.OnInspectorGUI();
            }
        }


        /// ----------------------------------------------------------------------------
        #region Static
        
        private static readonly string SettingPath
            = Path.Combine(SettingsProviderKey.ProjectSettings, "Custom/Runtime");

        [SettingsProvider]
        public static SettingsProvider CreateProvider() {
            return new ProjectSettingsProvider(SettingPath, SettingsScope.Project, null);
        }

        private static void CreateSettings() {
            var config = ScriptableObject.CreateInstance<ProjectSettingsSO>();
            var parent = "Assets/Resources";
            if (AssetDatabase.IsValidFolder(parent) == false) {
                // Resourcesフォルダが無いことを考慮
                AssetDatabase.CreateFolder("Assets", "Resources");
            }

            var assetPath = Path.Combine(parent, Path.ChangeExtension(nameof(ProjectSettingsSO), ".asset"));
            AssetDatabase.CreateAsset(config, assetPath);
        }
        #endregion
    }

}

#if false

#endif