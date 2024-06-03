Public Class Novo_Produto
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles img_prod.Click
        Try
            With OpenFileDialog1
                .Title = "Selecione uma Foto"
                .InitialDirectory = Application.StartupPath & "\produtos\"
                .ShowDialog()
                dir_foto = .FileName
                img_prod.Load(dir_foto)
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub btn_adicionar_Click(sender As Object, e As EventArgs) Handles btn_adicionar.Click
        If txt_id.Text = "" Or
            txt_preco.Text = "" Or
            cmb_categoria.Text = "" Or
            txt_produto.Text = "" Then
            MsgBox("Preencha todos os campos!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End If

        Try
            If cmb_categoria.Text = "Salgados" Then
                sql = "select * from tb_salgados_exclusivos where codigo ='" & txt_id.Text & "'"
                rs = db.Execute(sql)
                If rs.EOF = True Then
                    sql = "insert into tb_salgados_exclusivos (codigo,produto,preco,imagen) values ('" & txt_id.Text & "', " &
                    "'" & txt_produto.Text & "', " &
                    "'" & txt_preco.Text & "', " &
                    "'" & dir_foto & "')"
                    rs = db.Execute(sql)
                    MsgBox("Produto gravado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                End If
            ElseIf cmb_categoria.Text = "Doces" Then
                sql = "select * from tb_doces_exclusivos where codigo ='" & txt_id.Text & "'"
                rs = db.Execute(sql)
                If rs.EOF = True Then
                    sql = "insert into tb_doces_exclusivos (codigo,produto,preco,imagen) values ('" & txt_id.Text & "', " &
                    "'" & txt_produto.Text & "', " &
                    "'" & txt_preco.Text & "', " &
                    "'" & dir_foto & "')"
                    rs = db.Execute(sql)
                    MsgBox("Produto gravado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao gravar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub btn_retornar_Click(sender As Object, e As EventArgs) Handles btn_retornar.Click
        Me.Close()
    End Sub

    Private Sub Novo_Produto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar_banco()
    End Sub

    Private Sub btn_limpar_Click(sender As Object, e As EventArgs) Handles btn_limpar.Click
        txt_id.Clear()
        txt_preco.Clear()
        cmb_categoria.Text = ""
        txt_produto.Clear()
        txt_id.Focus()
        img_prod.Load(Application.StartupPath & "\icones\maisao.png")
    End Sub
End Class