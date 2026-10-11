Imports System.Data.SQLite

Public Class Form1
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' データベースファイルのパスを指定（存在しない場合は新規作成される）
        Dim dbPath As String = "Data Source=StarEnergy.db"

        Using connection As New SqliteConnection(dbPath)
            connection.Open()

            Using command As New SqliteCommand("SELECT * FROM EnemyData", connection)
                Using reader As SqliteDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' カラム名やインデックスでデータを取得
                        Console.WriteLine($"ID: {reader("ID")} | Name: {reader("Name")}")
                        TextBox6.Text = reader("ID")
                        TextBox1.Text = reader("Name")
                    End While
                End Using
            End Using

            connection.Close()
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
' Copyright by Kyosuke Miyazawa 2026/10/8 All Right Reserved
