## 開発環境
- Unity
  - ver.6000.2.9f1
- VR
  - Meta Quest3

## 実装方法メモ
### 手の表示位置を変化させた方法
（ロジックはex2同様）

※ver.6000.2.9f1では、調べて実装した感じOVR管理下の取得した手の座標を**スクリプトで上書き不可能だったため**、ex2とは異なり、別で手のオブジェクトを用いる方法で実装
1. ゲーム中に表示する手のオブジェクトだけを扱う空オブジェクト```HandController```をヒエラルキーに配置
2. ```OVRCameraRig > OVRInteraction > OVRHands > Left(Right)HandSynthetic > OVRLeft(Right)HandVisual > OculusHand_L(R)```からハンドトラッキングした手の座標データが取得できるため、スクリプト（ChangeHandTrackPosition.cs）でその値をもとに表示する手のオブジェクトの位置を変更

### ゲームに関して
- GameManagerをActiveにするとゲームが始まる
- GameManagerは「フルーツの落下（```GameManager > FruitSpawner```）」「スコア（```GameManager > Canvas > ScoreText```）」「制限時間```GameManager > Canvas > TimeText```」等を一元管理している空のオブジェクト
- BGMの切り替わりは、GameManangerがアクティブか非アクティブかが条件
- フルーツの落下全般に関しては、```GameManager > FruitSpawner```にアタッチされているスクリプトのプロパティから変更可能 
