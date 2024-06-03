Imports System.Net.Security

Public Class Produtos
    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        resp = MsgBox("Deseja mesmo encerrar programa??", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "AVISO")
        If resp = vbYes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btn_encerrar_Click(sender As Object, e As EventArgs) Handles btn_encerrar.Click
        Me.Close()
        Menu_Principal.Show()
        If tipo = "CLIENTE" Then
            Menu_Principal.btn_adm.Visible = False
        ElseIf tipo = "ADMIN" Then
            Menu_Principal.btn_adm.Visible = True
        End If
    End Sub

    'colocando os produtos no carrinho
    Private Sub btn_pfran_Click(sender As Object, e As EventArgs) Handles btn_pfran.Click
        Try
            sql = "select * from tb_estoque where id_produto='P01'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_pfranint_Click(sender As Object, e As EventArgs) Handles btn_pfranint.Click
        Try
            sql = "select * from tb_estoque where id_produto='P02'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_pit_Click(sender As Object, e As EventArgs) Handles btn_pit.Click
        Try
            sql = "select * from tb_estoque where id_produto='P03'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_pgrao_Click(sender As Object, e As EventArgs) Handles btn_pgrao.Click
        Try
            sql = "select * from tb_estoque where id_produto='P04'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_bag_Click(sender As Object, e As EventArgs) Handles btn_bag.Click
        Try
            sql = "select * from tb_estoque where id_produto='P05'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_bagqueijo_Click(sender As Object, e As EventArgs) Handles btn_bagqueijo.Click
        Try
            sql = "select * from tb_estoque where id_produto='P06'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_croissant_Click(sender As Object, e As EventArgs) Handles btn_croissant.Click
        Try
            sql = "select * from tb_estoque where id_produto='P07'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_austr_Click(sender As Object, e As EventArgs) Handles btn_austr.Click
        Try
            sql = "select * from tb_estoque where id_produto='P08'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_ciab_Click(sender As Object, e As EventArgs) Handles btn_ciab.Click
        Try
            sql = "select * from tb_estoque where id_produto='P09'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_pqueijo_Click(sender As Object, e As EventArgs) Handles btn_pqueijo.Click
        Try
            sql = "select * from tb_estoque where id_produto='P10'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_bisn_Click(sender As Object, e As EventArgs) Handles btn_bisn.Click
        Try
            sql = "select * from tb_estoque where id_produto='P11'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_bbrig_Click(sender As Object, e As EventArgs) Handles btn_bbrig.Click
        Try
            sql = "select * from tb_estoque where id_produto='D01'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_bmor_Click(sender As Object, e As EventArgs) Handles btn_bmor.Click
        Try
            sql = "select * from tb_estoque where id_produto='D02'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_brown_Click(sender As Object, e As EventArgs) Handles btn_brown.Click
        Try
            sql = "select * from tb_estoque where id_produto='D03'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_bchoc_Click(sender As Object, e As EventArgs) Handles btn_bchoc.Click
        Try
            sql = "select * from tb_estoque where id_produto='D04'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_cann_Click(sender As Object, e As EventArgs) Handles btn_cann.Click
        Try
            sql = "select * from tb_estoque where id_produto='D05'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_sonhoc_Click(sender As Object, e As EventArgs) Handles btn_sonhoc.Click
        Try
            sql = "select * from tb_estoque where id_produto='D06'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_sonhodl_Click(sender As Object, e As EventArgs) Handles btn_sonhodl.Click
        Try
            sql = "select * from tb_estoque where id_produto='D07'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_torta_Click(sender As Object, e As EventArgs) Handles btn_torta.Click
        Try
            sql = "select * from tb_estoque where id_produto='D08'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_cafeexp_Click(sender As Object, e As EventArgs) Handles btn_cafeexp.Click
        Try
            sql = "select * from tb_estoque where id_produto='B01'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_cafeleit_Click(sender As Object, e As EventArgs) Handles btn_cafeleit.Click
        Try
            sql = "select * from tb_estoque where id_produto='B02'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_cafemac_Click(sender As Object, e As EventArgs) Handles btn_cafemac.Click
        Try
            sql = "select * from tb_estoque where id_produto='B03'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_capp_Click(sender As Object, e As EventArgs) Handles btn_capp.Click
        Try
            sql = "select * from tb_estoque where id_produto='B04'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_cha_Click(sender As Object, e As EventArgs) Handles btn_cha.Click
        Try
            sql = "select * from tb_estoque where id_produto='B05'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_choco_Click(sender As Object, e As EventArgs) Handles btn_choco.Click
        Try
            sql = "select * from tb_estoque where id_produto='B06'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub btn_suco_Click(sender As Object, e As EventArgs) Handles btn_suco.Click
        Try
            sql = "select * from tb_estoque where id_produto='B08'"
            rs = db.Execute(sql)
            With dgv_carrinho
                .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, Nothing)
            End With
        Catch ex As Exception
            MsgBox("Erro ao adicionar produto", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Private Sub Produtos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar_banco()
        preco_total()
    End Sub

    Private Sub btn_calcular_Click(sender As Object, e As EventArgs) Handles btn_calcular.Click
        calcular_total()
    End Sub

    Private Sub dgv_carrinho_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_carrinho.CellContentClick
        Try
            With dgv_carrinho
                If .CurrentRow.Cells(3).Selected = True Then
                    cont = .CurrentRow.Index
                    .Rows.RemoveAt(cont)
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro ao remover do carrinho", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Sub preco_total()
        Dim contar_preco As Double = 0
        For rowitem As Double = 0 To dgv_carrinho.RowCount - 1
            contar_preco = contar_preco + Val(dgv_carrinho.Rows(rowitem).Cells(2).Value)
        Next
        lbl_total.Text = contar_preco
    End Sub

    Private Sub btn_finalizar_Click(sender As Object, e As EventArgs) Handles btn_finalizar.Click
        Try
            calcular_total()
            sql = "select * from tb_login where email='" & aux_usuario & "' or nome='" & aux_usuario & "'"
            rs = db.Execute(sql)
            'cont = 0
            'max = 2L
            listprod.Text = ""
            For Each row As DataGridViewRow In dgv_carrinho.Rows
                If Not row.IsNewRow Then
                    aux_produto = row.Cells(1).Value
                    aux_precoProd = row.Cells(2).Value
                    listprod.Text += "  1x ... " & ("" & aux_produto & ".") & " ................... " & ("" & aux_precoProd & ".") & "\n"
                End If
            Next
            dgv_carrinho.Rows.Clear()
            'With dgv_carrinho
            'Do While cont <= max
            'max = .ColumnCount
            'aux_produto = .Rows(cont).Cells(1).Value
            'listprod.Text += "1x....." & ("" & aux_produto & ", ") & "\n"
            'cont = cont + 1
            'Loop
            '.Rows.Clear()
            'End With
            Process.Start("https://api.callmebot.com/whatsapp.php?phone=+5511994971951&text='" & aux_nome & " reservou os seguintes produtos: \n" & "\n-------------------------------------------------------------\n" &
                          listprod.Text & "-------------------------------------------------------------\n" & "%0ATOTAL: ................................................. R$ " & lbl_total.Text & "'&apikey=2804612")
            resp = MsgBox("Compra confirmada! Dono da padaria irá te contatar quando os produtos estiverem prontos para coleta." & vbNewLine & "Gostaria de receber uma mensagem com os detalhes da compra?", vbInformation + vbYesNo, "Atenção")
            If resp = vbYes Then
                aux_telefone = InputBox("Escreva o número de telefone que irá receber a mensagem.")
                aux_api = InputBox("Escreva a chave API do CallMeBot correspondente.")
                Process.Start("https://api.callmebot.com/whatsapp.php?phone=+55" & aux_telefone & "&text='" & aux_nome & " reservou os seguintes produtos: \n" & "\n-------------------------------------------------------------\n" &
                          listprod.Text & "-------------------------------------------------------------\n" & "%0ATOTAL: ................................................. R$ " & lbl_total.Text & "'&apikey=" & aux_api & "")
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Erro ao finalizar compra!!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub
End Class