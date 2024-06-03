Public Class Autenticacao
    Private Sub Autenticacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar_banco()
        'carregar_tipo()
        carregar_logins()

    End Sub

    Private Sub btn_entrar_Click(sender As Object, e As EventArgs) Handles btn_entrar.Click

        If txt_autenticacao.Text = "" Or
           txt_senha.Text = "" Then
            MsgBox("Preencha todos os campos!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End If

        Try
            sql = "select * from tb_login WHERE email ='" & txt_autenticacao.Text & "' or nome='" & txt_autenticacao.Text & "' and senha ='" & txt_senha.Text & "'"
            rs = db.Execute(sql)
            If rs.EOF = False And rs.Fields(5).Value = "CLIENTE" Then
                MsgBox("Bem-Vindo(a), Cliente!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                txt_autenticacao.Clear()
                txt_senha.Clear()
                Me.Hide()
                Menu_Principal.Show()
                aux_usuario = txt_autenticacao.Text
                aux_nome = rs.Fields(0).Value
                tipo = "CLIENTE"
                Menu_Principal.btn_adm.Visible = False
            ElseIf rs.EOF = False And rs.Fields(5).Value = "ADMINISTRADOR" Then
                MsgBox("Bem-Vindo(a), Administrador!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                txt_autenticacao.Clear()
                txt_senha.Clear()
                Me.Hide()
                Admin.Show()
                tipo = "ADMIN"
                ' aux_usuario = txt_autenticacao.Text
                'aux_nome = rs.Fields(0).Value
                Menu_Principal.btn_adm.Visible = True

            End If
        Catch ex As Exception
            MsgBox("Credenciais incorretas!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try

    End Sub

    Private Sub chk_visualizar_CheckedChanged(sender As Object, e As EventArgs) Handles chk_visualizar.CheckedChanged
        If (chk_visualizar.Checked) Then
            txt_senha.PasswordChar = ""
        Else
            txt_senha.PasswordChar = "•"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            aux_telefone = InputBox("Escreva o número de telefone que irá receber a mensagem.", "Recuperação De Senha")
            aux_api = InputBox("Escreva a chave API do CallMeBot correspondente.", "Recuperação De Senha")
            aux_usuario = InputBox("Escreva o e-mail da sua conta.", "Recuperação De Senha")
            sql = "select * from tb_login where email='" & aux_usuario & "'"
            rs = db.Execute(sql)
            Process.Start("https://api.callmebot.com/whatsapp.php?phone=+55" & aux_telefone & "&text='Sua senha é " & rs.Fields(4).Value & "'&apikey=" & aux_api & "")
        Catch ex As Exception
            MsgBox("Erro na recuperação de senha", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        resp = MsgBox("Deseja mesmo encerrar programa??", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "AVISO")
        If resp = vbYes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub lkl_cadastrar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkl_cadastrar.LinkClicked
        Me.Hide()
        Cadastro.Show()
    End Sub

    Private Sub btn_limpar_Click(sender As Object, e As EventArgs) Handles btn_limpar.Click
        txt_autenticacao.Clear()
        txt_senha.Clear()
    End Sub
End Class