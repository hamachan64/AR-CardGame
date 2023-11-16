# AR-CardGame
【Assets】
Spatial Awarenessについて変更した設定プロファイル

【Scripts】
AR Card Game で使用する Script

DisplayPriority.cs : 
4つのマーカーが印刷された1枚の物理カードに映像投影する際，
映像が重ならないように優先順位をつけて1つのマーカーのみ映像投影を行うためのコード

JudgeVis.cs : 
カードが認識されているか判定するためのコード

RederingManager.cs : 
レンダリング解像度を調節するためのコード

SensorConnect.cs : 
ToFセンサから距離情報を取得し、カードの映像を投影するためのコード

SwitchCard.cs : 
1マーカーのARカードと4マーカーのARカードのどちらで実験するか選択するためのコード

server.py : 
ToFセンサで距離情報を取得し、HoloLensへ送るためのコード