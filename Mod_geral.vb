Imports System.Data.OleDb

Module Mod_geral
    Public db As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public sql, resp As String
    Public dir_banco = Application.StartupPath & "\Banco_Dados\BD_Padaria.mdb"
    Public cont, max As Integer
    Public aux_nome, aux_cpf, aux_produto, aux_precoProd, aux_usuario, aux_hora, aux_data, aux_cod As String
    Public aux_id, aux_telefone, aux_api As String
    Public dir_foto As String
    Public tipo As String

    'teste
    Private cn As New OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source =" & dir_banco)


    Sub conectar_banco()
        Try
            db = CreateObject("ADODB.Connection")
            db.Open("Provider=Microsoft.JET.OLEDB.4.0;Data Source =" & dir_banco)
            ' MsgBox("Conectado com o banco!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
        Catch ex As Exception
            MsgBox("Erro ao conectar com o banco!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Sub calcular_total()
        Dim total As Double = 0
        Dim i As Integer = 0
        For Each row As DataGridViewRow In Produtos.dgv_carrinho.Rows
            If Not row.IsNewRow AndAlso Not row.Cells("Column3").Value Is Nothing Then
                Dim valor As Double = CDbl(row.Cells("Column3").Value)
                total += valor
            End If
        Next
        Produtos.lbl_total.Text = total.ToString()
    End Sub


    Sub carregar_estoque()
        Try
            sql = "select * from tb_estoque order by id_produto asc"
            rs = db.Execute(sql)
            With Admin.dgv_estoque
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, Nothing)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados do estoque!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    'Sub carregar_tipo()
    'Try
    'With Admin.cmb_tipo_conta2.Items
    '.Add("CLIENTE")
    '.Add("ADMINISTRADOR")
    'End With
    'Catch ex As Exception
    '       MsgBox("Erro ao carregar cmboxes!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
    'End Try
    'End Sub

    Sub carregar_cmbox()

        Try
            With Reservas.cmb_area.Items
                .Add("INTERIOR")
                .Add("EXTERIOR")
            End With
            With Reservas.cmb_mesas.Items
                .Add("1")
                .Add("2")
                .Add("3")
                .Add("4")
                .Add("5")
                .Add("6")
                .Add("7")
                .Add("8")
                .Add("9")
                .Add("10")
                .Add("11")
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar cmboxes!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try

    End Sub

    Sub carregar_area()
        With Calendario.cmb_area.Items
            .Add("Interior")
            .Add("Exterior")
        End With
    End Sub

    Sub carregar_horas()
        With Calendario.cmb_hora.Items
            .Add("10:00")
            '.Add("10:30")
            .Add("11:00")
            '.Add("11:30")
            .Add("12:00")
            '.Add("12:30")
            .Add("13:00")
            ' .Add("13:30")
            .Add("14:00")
            '.Add("14:30")
            .Add("15:00")
            '.Add("15:30")
            .Add("16:00")
            '.Add("16:30")
            .Add("17:00")
            '.Add("17:30")
            .Add("18:00")
            '.Add("18:30")
            .Add("19:00")
        End With
    End Sub

    Sub carregar_parametros()
        With Admin.cmb_parametro.Items
            .Add("nome")
            .Add("cpf")
            .Add("email")
        End With

        With Admin.cmb_parametros2.Items
            .Add("nome")
            .Add("data")
        End With

    End Sub
    Sub carregar_interno()
        With Calendario.cmb_mesa.Items
            .Add("1")
            .Add("2")
            .Add("3")
            .Add("4")
            .Add("5")
            .Add("6")
            .Add("7")
            .Add("8")
            .Add("9")
            .Add("10")
            .Add("11")
        End With
    End Sub

    Sub carregar_externo()
        With Calendario.cmb_mesa.Items
            .Add("1")
            .Add("2")
            .Add("3")
            .Add("4")
            .Add("5")
            .Add("6")
        End With
    End Sub

    Sub carregar_reservas()
        Try
            sql = "select * from tb_booking order by data"
            rs = db.Execute(sql)
            With Admin.dgv_reservas
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, rs.Fields(4).Value, rs.Fields(5).Value, Nothing)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados de reservas!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Sub carregar_logins()
        Try
            sql = "select * from tb_login order by nome asc"
            rs = db.Execute(sql)
            With Admin.dgv_login
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, rs.Fields(4).Value, rs.Fields(5).Value, Nothing, Nothing)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados de login!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Sub carregar_salgados()
        Try
            sql = "select * from tb_salgados_exclusivos order by id asc"
            rs = db.Execute(sql)
            With Beneficios_Reserva.dgv_salgexclusivos
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(2).Value, rs.Fields(3).Value)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar salgados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub
    Sub carregar_salgados_admin()
        Try
            sql = "select * from tb_salgados_exclusivos order by id asc"
            rs = db.Execute(sql)
            With Admin.dgv_salgexclusivos
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(Nothing, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, Nothing)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar salgados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Sub carregar_doces_admin()
        Try
            sql = "select * from tb_doces_exclusivos order by id asc"
            rs = db.Execute(sql)
            With Admin.dgv_docexclusivos
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(Nothing, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, Nothing, Nothing)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar doces!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Sub carregar_doces()
        Try
            sql = "select * from tb_doces_exclusivos order by id asc"
            rs = db.Execute(sql)
            With Beneficios_Reserva.dgv_docexclusivos
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(2).Value, rs.Fields(3).Value)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar doces!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub
    Sub carrefar_fluxo_deb()
        Try
            sql = "select * from tb_fluxo_deb order by id asc"
            rs = db.Execute(sql)
            With Admin.dgv_fluxo_deb
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados do fluxo!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Sub carrefar_fluxo_cred()
        Try
            sql = "select * from tb_fluxo_cred order by id asc"
            rs = db.Execute(sql)
            With Admin.dgv_fluxo_cred
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados do fluxo!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENÇÃO")
        End Try
    End Sub

    Public Function QueryComoDataTable(ByVal sql As String) As DataTable
        Dim da As New OleDbDataAdapter(sql, cn)
        Dim ds As New DataSet
        da.Fill(ds, "result")
        Return ds.Tables("result")
    End Function

End Module
