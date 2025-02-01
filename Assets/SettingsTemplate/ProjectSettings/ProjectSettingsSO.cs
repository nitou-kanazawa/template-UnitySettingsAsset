using System;
using UnityEngine;

// [REF]
//  qiita: Unityで独自の設定のUIを提供できるSettingsProviderの紹介と設定ファイルの保存について https://qiita.com/sune2/items/a88cdee6e9a86652137c

namespace Demo.Settings {

    /// <summary>
    /// Runtimeで参照するプロジェクト固有の設定データ．
    /// ※最初にProjectSettingsウインドウからアセットを作成する．
    /// </summary>
    public sealed class ProjectSettingsSO : ScriptableObject {

        #region Singleton
        private static ProjectSettingsSO _instance;
        public static ProjectSettingsSO Instance {
            get {
                // [NOTE] Resources直下にクラス名と同名で配置されている必要がある．
                if (_instance == null)
                    _instance = Resources.Load<ProjectSettingsSO>(nameof(ProjectSettingsSO));

                if (Application.isPlaying && _instance == null)
                    throw new InvalidOperationException($"{nameof(ProjectSettingsSO)} could not be loaded from the Resources folder. Please ensure it is properly placed.");

                return _instance;
            }
        }
        #endregion

        [SerializeField]
        private SettingData _data;

        public SettingData Data => _data;
    }

    [Serializable]
    public struct SettingData {
        public int num1;
        public int num2;
        public bool flag;
    }
}
