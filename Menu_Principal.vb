Public Class Menu_Principal
    Private Sub btn_produtos_Click(sender As Object, e As EventArgs) Handles btn_produtos.Click
        Me.Close()
        Produtos.Show()
    End Sub

    Private Sub btn_reservas_Click(sender As Object, e As EventArgs) Handles btn_reservas.Click
        Me.Close()
        DisplayClandario.Show()
    End Sub

    Private Sub btn_encerrar_Click(sender As Object, e As EventArgs) Handles btn_encerrar.Click
        resp = MsgBox("Deseja mesmo encerrar sessão?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "AVISO")
        If resp = vbYes Then
            Me.Close()
            Autenticacao.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btn_adm_Click(sender As Object, e As EventArgs) Handles btn_adm.Click
        Me.Close()
        Admin.Show()
    End Sub

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        resp = MsgBox("Deseja mesmo encerrar programa??", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "AVISO")
        If resp = vbYes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub
End Class