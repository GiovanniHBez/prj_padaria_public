Public Class Cadastro
    Private Sub btn_retornar_Click(sender As Object, e As EventArgs) Handles btn_retornar.Click
        Me.Close()
        Autenticacao.Show()

    End Sub

    Private Sub ckb_versenhas_CheckedChanged(sender As Object, e As EventArgs) Handles ckb_versenhas.CheckedChanged
        If (ckb_versenhas.Checked) Then
            txt_pass.PasswordChar = ""
            txt_confpass.PasswordChar = ""
        Else
            txt_pass.PasswordChar = "•"
            txt_confpass.PasswordChar = "•"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txt_cpf.Text = "" Or
          txt_usuario.Text = "" Or
          txt_email2.Text = "" Or
          txt_confemail.Text = "" Or
          txt_pass.Text = "" Or
          txt_confpass.Text = "" Then
            MsgBox("Preencha todos os campos!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        ElseIf txt_email2.Text <> txt_confemail.Text Then
            MsgBox("E-mails não conferem!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        ElseIf txt_pass.Text <> txt_confpass.Text Then
            MsgBox("Senhas não conferem!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        Else
            Try
                sql = "select * from tb_login where cpf ='" & txt_cpf.Text & "'"
                rs = db.Execute(sql)
                If rs.EOF = True Then ' se não existir o cpf na tab do banco
                    sql = "insert into tb_login values ('" & txt_usuario.Text & "', " &
                    "'" & txt_cpf.Text & "', " &
                    "'" & txt_contato.Text & "', " &
                    "'" & txt_email2.Text & "', " &
                    "'" & txt_pass.Text & "', " &
                    " 'CLIENTE')"
                    rs = db.Execute(sql)
                    MsgBox("Dados gravados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Sucesso!")
                    carregar_logins()
                    txt_cpf.Clear()
                    txt_contato.Clear()
                    txt_usuario.Clear()
                    txt_email2.Clear()
                    txt_confemail.Clear()
                    txt_pass.Clear()
                    txt_confpass.Clear()
                    txt_usuario.Focus()
                Else
                    MsgBox("CPF já cadastrado!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção!")
                    carregar_logins()
                    txt_cpf.Clear()
                    txt_contato.Clear()
                    txt_usuario.Clear()
                    txt_email2.Clear()
                    txt_confemail.Clear()
                    txt_pass.Clear()
                    txt_confpass.Clear()
                    txt_usuario.Focus()
                End If
            Catch ex As Exception
                MsgBox("Erro ao gravar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
            End Try
        End If
    End Sub

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        resp = MsgBox("Deseja mesmo encerrar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "AVISO")
        If resp = vbYes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub
End Class
