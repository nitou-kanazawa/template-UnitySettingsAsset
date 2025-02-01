#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

// [REF]
//  qiita: Unityで独自の設定のUIを提供できるSettingsProviderの紹介と設定ファイルの保存について https://qiita.com/sune2/items/a88cdee6e9a86652137c

namespace Demo.Settings {

    internal sealed class PreferencesProvider : SettingsProvider{

        private Editor _editor;


        /// ----------------------------------------------------------------------------
        // Public Method

        public PreferencesProvider(string path, SettingsScope scopes, IEnumerable<string> keywords) : base(path, scopes, keywords) {}

        public override void OnActivate(string searchContext, VisualElement rootElement) {

            var preferences = PreferencesSO.instance;
            
            // ※ScriptableSingletonを編集可能にする
            preferences.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            // 設定ファイルの標準のインスペクターのエディタを生成
            Editor.CreateCachedEditor(preferences, null, ref _editor);
        }

        public override void OnGUI(string searchContext) {

            EditorGUI.BeginChangeCheck();

            // 設定ファイルの標準インスペクタを表示
            _editor.OnInspectorGUI();

            if (EditorGUI.EndChangeCheck()) {
                PreferencesSO.instance.Save();
            }
        }


        /// ----------------------------------------------------------------------------
        #region Static

        private static readonly string SettingPath 
            = Path.Combine(SettingsProviderKey.Preference, "Custom/My Preferences");

        [SettingsProvider]
        public static SettingsProvider CreateSettingProvider() {
            return new PreferencesProvider(SettingPath, SettingsScope.User, null);
        }
        #endregion
    }
}
#endif