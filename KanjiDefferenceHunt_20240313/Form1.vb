Public Class FormGame
    Dim correctText As String = "荻"       '正解の文字：1つだけ
    Dim mistakeText As String = "萩"       '間違いの文字：24個並ぶ
    Dim nowTime As Double       '経過時間
    Dim shortestTime As Double = Double.MaxValue        '最短時間（最初は最大値を格納しておく）
    Dim previousTime As Double                          '前回時間（最初は0）

    '画面下部の25個のボタンいずれかをクリックした時（共通で呼ばれる）
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click,
                                                                       Button20.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click,
                                                                       Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click,
                                                                       Button10.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click,
                                                                       Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click
        If CType(sender, Button).Text = correctText Then
            Timer1.Stop()   '時間計測の終了
            'タイマーストップ時のnowtimeが最短クリア時間か？
            '最短の場合
            If nowTime < shortestTime Then
                shortestTime = nowTime      '最短時間の変数に今回の時間を格納
            End If

            'メッセージを表示
            MessageBox.Show("最短クリア時間：" & shortestTime.ToString("0.00") &
                            vbCrLf &
                            "前回クリア時間：" & previousTime.ToString("0.00"))

            '前回クリア時間として保持
            previousTime = nowTime
        Else
            nowTime = nowTime + 10  'ペナルティー10秒
        End If

    End Sub

    'スタートボタンをクリックした時
    Private Sub Button_Start_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        TextHunt.Text = correctText   '探す文字を表示
        Dim Rnd As New Random() '乱数を生成する為のインスタンスを生成（インスタンス化）
        Dim randomResult As Integer = Rnd.Next(25)   '0～24の乱数を取得
        'SplitContainerの下部のPanel2に乗っている
        'ButtonのTextを全て間違いの文字にする
        For i As Integer = 0 To SplitContainer1.Panel2.Controls.Count - 1
            SplitContainer1.Panel2.Controls(i).Text = mistakeText
        Next
        'ランダムで1つだけ正解の文字にする
        SplitContainer1.Panel2.Controls(randomResult).Text = correctText
        'タイマースタート
        nowTime = 0       'タイマーの初期化
        Timer1.Start()
    End Sub

    '0.02秒おきに呼ばれるタイマーのイベントハンドラー
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        nowTime = nowTime + 0.02
        TextTimer.Text = nowTime.ToString("0.00")
    End Sub
End Class
