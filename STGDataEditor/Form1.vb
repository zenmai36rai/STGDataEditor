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
                        RichTextBox1.Text += ($"ID: {reader("ID")} | Name: {reader("Name")}") + vbLf
                        TextBox6.Text = reader("ID")
                        TextBox1.Text = reader("Name")
                    End While
                End Using
            End Using

            connection.Close()
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' データベースファイルのパスを指定（存在しない場合は新規作成される）
        Dim connectionString As String = "Version=3;Data Source=StarEnergy.db;New=False;Compress=True;"
        Dim dbPath As String = "Data Source=StarEnergy.db"
        Dim sql As String = "INSERT INTO EnemyData (ID, Name) VALUES (@ID, @Name);"

        Using connection As New SQLiteConnection(connectionString)

            Using command As New SQLiteCommand(sql, connection)
                ' パラメータの追加
                command.Parameters.Add("@ID", DbType.Int16).Value = TextBox6.Text
                command.Parameters.Add("@Name", DbType.String).Value = TextBox1.Text

                connection.Open()
                ' データ追加・更新・削除の実行（影響を受けた行数を返す）
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
            End Using

            connection.Close()
        End Using

    End Sub
End Class
' Copyright by Kyosuke Miyazawa 2026/10/8 All Right Reserved
