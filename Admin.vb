Public Class Admin
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar_banco()
        carregar_estoque()
        carregar_logins()
        carrefar_fluxo_cred()
        carrefar_fluxo_deb()
        carregar_reservas()
        carregar_doces_admin()
        carregar_salgados_admin()
        carregar_parametros()
    End Sub

    Private Sub btn_cad_Click(sender As Object, e As EventArgs) Handles btn_cad.Click
        If txt_cpfcliente.Text = "" Or
           txt_nomecompleto.Text = "" Or
           txt_endemail.Text = "" Or
           txt_confendemail.Text = "" Or
           txt_passe.Text = "" Or
           txt_confpasse.Text = "" Or
           cmb_tipo_conta2.Text = "" Then
            MsgBox("Preencha todos os campos!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        ElseIf txt_endemail.Text <> txt_confendemail.Text Then
            MsgBox("E-mails não conferem!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        ElseIf txt_passe.Text <> txt_confpasse.Text Then
            MsgBox("Senhas não conferem!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        Else
            Try
                sql = "select * from tb_login where cpf ='" & txt_cpfcliente.Text & "'"
                rs = db.Execute(sql)
                If rs.EOF = True Then ' se não existir o cpf na tab do banco
                    sql = "insert into tb_login values ('" & txt_nomecompleto.Text & "', " &
                    "'" & txt_cpfcliente.Text & "', " &
                    "'" & txt_contatocliente.Text & "', " &
                    "'" & txt_endemail.Text & "', " &
                    "'" & txt_passe.Text & "', " &
                    "'" & cmb_tipo_conta2.Text & "')"
                    rs = db.Execute(sql)
                    MsgBox("Dados gravados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                    carregar_logins()
                    txt_cpfcliente.Clear()
                    txt_contatocliente.Clear()
                    txt_nomecompleto.Clear()
                    txt_endemail.Clear()
                    txt_confendemail.Clear()
                    txt_passe.Clear()
                    txt_confpasse.Clear()
                    cmb_tipo_conta2.Text = ""
                    txt_nomecompleto.Focus()
                Else
                    sql = "update tb_login set nome ='" & txt_nomecompleto.Text & "',contato='" & txt_contatocliente.Text & "', email='" & txt_endemail.Text & "', senha='" & txt_passe.Text & "', tipo = '" & cmb_tipo_conta2.Text & "'  where cpf='" & txt_cpfcliente.Text & "'"
                    rs = db.Execute(sql)
                    MsgBox("Dados alterados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                    carregar_logins()
                    txt_cpfcliente.Clear()
                    txt_contatocliente.Clear()
                    txt_nomecompleto.Clear()
                    txt_endemail.Clear()
                    txt_confendemail.Clear()
                    txt_passe.Clear()
                    txt_confpasse.Clear()
                    cmb_tipo_conta2.Text = ""
                    txt_nomecompleto.Focus()
                End If
            Catch ex As Exception
                MsgBox("Erro ao gravar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
            End Try
        End If
    End Sub

    Private Sub dgv_login_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_login.CellContentClick
        Try
            With dgv_login
                If .CurrentRow.Cells(6).Selected = True Then
                    aux_cpf = .CurrentRow.Cells(1).Value
                    sql = "select * from tb_login where cpf ='" & aux_cpf & "'"
                    rs = db.Execute(sql)
                    If rs.EOF = False Then
                        TabControl1.SelectTab(2)
                        TabPage1.Show()
                        txt_nomecompleto.Text = rs.Fields(0).Value
                        txt_cpfcliente.Text = rs.Fields(1).Value
                        'txt_contatocliente = rs.Fields(2).Value
                        txt_endemail.Text = rs.Fields(3).Value
                        txt_confendemail.Text = rs.Fields(3).Value
                        txt_passe.Text = rs.Fields(4).Value
                        txt_confpasse.Text = rs.Fields(4).Value
                        cmb_tipo_conta2.Text = rs.Fields(5).Value
                    End If
                ElseIf .CurrentRow.Cells(7).Selected = True Then
                    aux_nome = .CurrentRow.Cells(0).Value
                    resp = MsgBox("Deseja excluir o cliente : " & aux_nome & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete * from tb_login where nome = '" & aux_nome & "'"
                        rs = db.Execute(sql)
                        carregar_logins()
                    End If
                Else
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ckb_visualizar.CheckedChanged
        If (ckb_visualizar.Checked) Then
            txt_passe.PasswordChar = ""
            txt_confpasse.PasswordChar = ""
        Else
            txt_passe.PasswordChar = "•"
            txt_confpasse.PasswordChar = "•"
        End If
    End Sub

    Private Sub dgv_estoque_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_estoque.CellContentClick
        Try
            With dgv_estoque
                If .CurrentRow.Cells(4).Selected = True Then
                    aux_id = .CurrentRow.Cells(0).Value
                    sql = "select * from tb_estoque where id_produto='" & aux_id & "'"
                    rs = db.Execute(sql)
                    If rs.EOF = False Then
                        'editarestoque.Select()
                        editarestoque.Show()
                        editarestoque.txt_id.Text = rs.Fields(0).Value
                        editarestoque.txt_produto.Text = rs.Fields(1).Value
                        editarestoque.txt_preco.Text = rs.Fields(2).Value
                        editarestoque.txt_estoque.Text = rs.Fields(3).Value
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub btn_enviar_Click(sender As Object, e As EventArgs) Handles btn_enviar.Click
        If txt_conta.Text = "" Or
            txt_valor.Text = "" Or
            cmb_deboucred.Text = "" Then
            MsgBox("Preencha todos os campos", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End If
        Try
            If cmb_deboucred.Text = "Crédito" Then
                sql = "insert into tb_fluxo_cred (conta,valor,data) values('" & txt_conta.Text & "', " &
                                    "'" & txt_valor.Text & "', " &
                                    "'" & cmb_data_conta.Value.Date & "')"
                rs = db.Execute(sql)
                MsgBox("Dados enviados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                carrefar_fluxo_cred()
                cmb_deboucred.Text = ""
                txt_conta.Clear()
                txt_valor.Clear()
                cmb_data_conta.Value = Today
            ElseIf cmb_deboucred.Text = "Débito" Then
                sql = "insert into tb_fluxo_deb (conta,valor,data) values('" & txt_conta.Text & "', " &
                                    "'" & txt_valor.Text & "', " &
                                    "'" & cmb_data_conta.Value.Date & "')"
                rs = db.Execute(sql)
                MsgBox("Dados enviados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                carrefar_fluxo_deb()
                cmb_deboucred.Text = ""
                txt_conta.Clear()
                txt_valor.Clear()
                cmb_data_conta.Value = Today
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar fluxo", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        resp = MsgBox("Deseja mesmo encerrar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "AVISO")
        If resp = vbYes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub img_prod_Click(sender As Object, e As EventArgs) Handles img_prod.Click
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
                    sql = "insert into tb_salgados_exclusivos (codigo,produto,preco,imagem) values ('" & txt_id.Text & "', " &
                    "'" & txt_produto.Text & "', " &
                    "'" & txt_preco.Text & "', " &
                    "'" & dir_foto & "')"
                    rs = db.Execute(sql)
                    MsgBox("Produto gravado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                    carregar_salgados_admin()
                Else
                    MsgBox("ID já em uso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                End If
            ElseIf cmb_categoria.Text = "Doces" Then
                sql = "select * from tb_doces_exclusivos where codigo ='" & txt_id.Text & "'"
                rs = db.Execute(sql)
                If rs.EOF = True Then
                    sql = "insert into tb_doces_exclusivos (codigo,produto,preco,imagem) values ('" & txt_id.Text & "', " &
                    "'" & txt_produto.Text & "', " &
                    "'" & txt_preco.Text & "', " &
                    "'" & dir_foto & "')"
                    rs = db.Execute(sql)
                    MsgBox("Produto gravado com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                    carregar_doces_admin()
                Else
                    MsgBox("ID já em uso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao gravar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub btn_limpar_Click(sender As Object, e As EventArgs) Handles btn_limpar.Click
        txt_id.Clear()
        txt_preco.Clear()
        cmb_categoria.Text = ""
        txt_produto.Clear()
        txt_id.Focus()
        img_prod.Load(Application.StartupPath & "\icones\maisao.png")
    End Sub

    Private Sub dgv_salgexclusivos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_salgexclusivos.CellContentClick
        Try
            With dgv_salgexclusivos
                If .CurrentRow.Cells(4).Selected = True Then
                    aux_cod = .CurrentRow.Cells(1).Value
                    resp = MsgBox("Deseja excluir o produto : " & aux_cod & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete * from tb_salgados_exclusivos where codigo = '" & aux_cod & "'"
                        rs = db.Execute(sql)
                        carregar_salgados_admin()
                    End If
                Else
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub dgv_docexclusivos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_docexclusivos.CellContentClick
        Try
            With dgv_docexclusivos
                If .CurrentRow.Cells(4).Selected = True Then
                    aux_cod = .CurrentRow.Cells(1).Value
                    resp = MsgBox("Deseja excluir o produto : " & aux_cod & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete * from tb_doces_exclusivos where codigo = '" & aux_cod & "'"
                        rs = db.Execute(sql)
                        carregar_doces_admin()
                    End If
                Else
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Try
            If txt_api.Text = "" Or txt_promocao.Text = "" Or txt_numero_cliente.Text = "" Then
                MsgBox("Preencha todos os campos!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
            Else
                Process.Start("https://api.callmebot.com/whatsapp.php?phone=+55" & txt_numero_cliente.Text & "&text='" & txt_promocao.Text & "'&apikey=" & txt_api.Text & "")
                MsgBox("Promoção enviada com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
            End If
        Catch ex As Exception
            MsgBox("Erro no envio de promoção", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub dgv_reservas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_reservas.CellContentClick
        Try
            With dgv_reservas
                If .CurrentRow.Cells(6).Selected = True Then
                    aux_nome = .CurrentRow.Cells(3).Value
                    resp = MsgBox("Deseja excluir a reserva de : " & aux_nome & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ATENÇÃO")
                    If resp = MsgBoxResult.Yes Then
                        sql = "delete * from tb_booking where nome = '" & aux_nome & "'"
                        rs = db.Execute(sql)
                        carregar_reservas()
                    End If
                Else
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
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

    Private Sub btn_produtos_Click(sender As Object, e As EventArgs) Handles btn_produtos.Click
        Me.Close()
        Produtos.Show()
    End Sub

    Private Sub btn_reservas_Click(sender As Object, e As EventArgs) Handles btn_reservas.Click
        Me.Close()
        DisplayClandario.Show()
    End Sub

    Private Sub btn_menu_Click(sender As Object, e As EventArgs) Handles btn_menu.Click
        Me.Close()
        Menu_Principal.Show()
    End Sub

    Private Sub txt_filtrarNome_TextChanged(sender As Object, e As EventArgs) Handles txt_filtrarNome.TextChanged
        Try
            sql = "select * from tb_login where " & cmb_parametro.Text & " like '" & txt_filtrarNome.Text & "%'"
            rs = db.Execute(sql)
            With dgv_login
                .Rows.Clear()
                cont = 1
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, rs.Fields(4).Value, rs.Fields(5).Value, Nothing, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub txt_filtrarnome2_TextChanged(sender As Object, e As EventArgs) Handles txt_filtrarnome2.TextChanged
        Try
            sql = "select * from tb_booking where " & cmb_parametros2.Text & " like '" & txt_filtrarnome2.Text & "%'"
            rs = db.Execute(sql)
            With dgv_reservas
                .Rows.Clear()
                cont = 1
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, rs.Fields(4).Value, rs.Fields(5).Value, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
End Class