Public Class editarestoque
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            sql = "update tb_estoque set nome_produto ='" & txt_produto.Text & "', preco='" & txt_preco.Text & "', qtd_estoque = '" & txt_estoque.Text & "'  where id_produto='" & txt_id.Text & "'"
            rs = db.Execute(sql)
            MsgBox("Dados alterados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
            carregar_estoque()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_volta_Click(sender As Object, e As EventArgs) Handles btn_volta.Click
        Me.Close()
        Admin.Show()
    End Sub
End Class