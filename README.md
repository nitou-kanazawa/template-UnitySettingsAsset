# Unity Settings Asset
Projectの設定データ（Runtime / Editor）とその編集用エディタ拡張のたたき台．


## 概要


## GUIでのデータ編集

### Project Settings (Runtime)
データはResourcesフォルダ内に`ScriptableObject`として保存されます．

<img src="https://github.com/user-attachments/assets/dab13fd3-915a-41c4-9609-c63062c81168" alt="Provider_Preferece" width="600" />

### Project Settings (Editor)
データはテキスト形式で `プロジェクト名/ProjectSettings/` 以下に保存されます．（※プロジェクト固有）

<img src="https://github.com/user-attachments/assets/3914617c-f773-4341-b2c1-1688b5f4e1cd" alt="Provider_Preferece" width="600" />


### Preference
データはテキスト形式で` `に保存されます．（※複数プロジェクトで共通）

## 使い方
以下のフォルダを自分のUnityプロジェクトのAssets内（任意の場所）に配置します．



##　開発環境
　Unity 6000.0.30f1
