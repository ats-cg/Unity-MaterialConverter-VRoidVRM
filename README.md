# Unity-MaterialConverter-VroidVRM

## 概要
このUnityエディタ拡張は、UnityにインポートされたVRoidモデル（UniVRMでインポートされたVRM1.0系形式のVRoidモデル）のMaterialをURPで使用可能なシェーダが適用されたMaterialに変換する機能を提供します。

## 対象
- Universal Render Pipeline（URP）ベースのUnityプロジェクト
- UniVRMでインポートされたVRM1.0形式のVRoidモデル
  - その他のモデルについても本拡張機能を使用することは可能ですが、意図した挙動になるとは限りません

## 注意事項
- このプロジェクトは実験的であり、個人の趣味に基づいたもので、完全な機能性や安定性は保証されません
- この拡張機能の使用によって生じる問題や損害について、開発者は責任を負いません
- この拡張機能を完全に利用するためには、以下の外部ツールの2024年3月時点での最新版がプロジェクトに含まれている必要があります:
  - [UniVRM](https://github.com/vrm-c/UniVRM)：UnityでVRMを使うためのライブラリ
  - [liltoon](https://github.com/lilxyzw/lilToon): Unityの様々なレンダリングパイプラインに対応したアバター向けのシェーダ

## 使い方
1. SceneにMaterial変換対象のモデルを配置して、選択状態にする
    - モデルのGameObjectが複数の階層からなる場合は一番親のGameObjectを選択する
2. Unityエディタのメニューから「MatConv > Convert Materials > into XXX」（例：into URPLit Materials）を押す
    - 変換されたマテリアルを持つオブジェクトがPrefabとしてSceneの原点に配置されます
    - 変換されたMaterialファイルとそれらを適用したオブジェクトのPrefabファイルは、Sceneファイルと同じディレクトリ階層に作成された新しいディレクトリ内に出力されます
  
![image](https://github.com/ats-cg/Unity-MaterialConverter-VRoidVRM/assets/114890115/f399b1c6-8e58-4f1c-8aac-845837c27b2a)
