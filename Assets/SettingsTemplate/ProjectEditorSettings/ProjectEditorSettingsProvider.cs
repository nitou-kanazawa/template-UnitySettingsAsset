#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System.IO;

namespace Demo.Settings {

    internal sealed class ProjectEditorSettingsProvider : SettingsProvider {

        private Editor _editor;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public ProjectEditorSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords) : base(path, scopes, keywords) { }

        /// <summary>
        /// 
        /// </summary>
        public override void OnActivate(string searchContext, VisualElement rootElement) {

            var preferences = ProjectEditorSettingsSO.instance;

            // ※ScriptableSingletonを編集可能にする
            preferences.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            // 設定ファイルの標準のインスペクターのエディタを生成
            Editor.CreateCachedEditor(preferences, null, ref _editor);
        }

        /// <summary>
        /// 描画処理．
        /// </summary>
        public override void OnGUI(string searchContext) {

            EditorGUI.BeginChangeCheck();

            // 設定ファイルの標準インスペクタを表示
            _editor.OnInspectorGUI();

            if (EditorGUI.EndChangeCheck()) {
                ProjectEditorSettingsSO.instance.Save();
            }
        }


        /// ----------------------------------------------------------------------------
        #region Static

        private static readonly string SettingPath
            = Path.Combine(SettingsProviderKey.ProjectSettings, "Custom/Editor");

        [SettingsProvider]
        public static SettingsProvider CreateSettingProvider() {
            // ※第三引数のkeywordsは、検索時にこの設定項目を引っかけるためのキーワード
            return new ProjectEditorSettingsProvider(SettingPath, SettingsScope.Project, null);
        }
        #endregion
    }
}
#endif