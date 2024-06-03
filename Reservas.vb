Public Class Reservas
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregar_cmbox()
    End Sub

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        resp = MsgBox("Deseja mesmo encerrar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "AVISO")
        If resp = vbYes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btn_encerrar_Click(sender As Object, e As EventArgs) Handles btn_encerrar.Click
        Me.Close()
        Menu_Principal.Show()

    End Sub
End Class