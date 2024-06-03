Imports System.Net.Security

Public Class DisplayClandario

    Private listarfldia As New List(Of FlowLayoutPanel)
    Private diaatual As DateTime = DateTime.Today

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        resp = MsgBox("Deseja mesmo encerrar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "AVISO")
        If resp = vbYes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub DisplayClandario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar_banco()
        gerarpaineldedias(40)
        displaydiaatual()
    End Sub

    Private Sub Fazer_Reserva(ByVal sender As Object, e As EventArgs)

        Dim dia As Integer = CType(sender, FlowLayoutPanel).Tag

        If dia <> 0 Then
            With Calendario
                .id_reserva = 0
                .txt_nome.Text = ""
                .cmb_area.Items.Clear()
                .cmb_hora.Items.Clear()
                .cmb_mesa.Items.Clear()
                .dtp_data.Value = New Date(diaatual.Year, diaatual.Month, dia)
                .ShowDialog()
            End With
            displaydiaatual()
        End If


    End Sub

    'pensando em utilizar essa função
    Private Sub Mostrar_Reserva(sender As Object, e As EventArgs)
        Dim ID_Reserva As Integer = CType(sender, LinkLabel).Tag
        Dim sql As String = $"select * from tb_booking where id ={ID_Reserva}"
        Dim dt As DataTable = QueryComoDataTable(sql)
        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            With Calendario
                .id_reserva = ID_Reserva
                .txt_nome.Text = row("cpf")
                .cmb_area.Text = row("area")
                .cmb_hora.Text = row("hora")
                .cmb_mesa.Text = row("mesa")
                .dtp_data.Value = row("data")
                .ShowDialog()
            End With
            displaydiaatual()
        End If
    End Sub
    Private Sub AdicionarReservaNoDia(ByVal IniciarDiaflNumero As Integer)

        Dim InicioData As DateTime = New Date(diaatual.Year, diaatual.Month, 1)
        Dim FimData As DateTime = InicioData.AddMonths(1).AddDays(-1)

        'Dim sql As String = $"select * from tb_booking where data between #{InicioData.ToShortDateString()}# and #{FimData.ToShortDateString()}#"
        Dim sql As String = $"select * from tb_booking where data between #{Format(InicioData, "yyyy/MM/dd")}# and #{Format(FimData, "yyyy/MM/dd")}#"
        Dim dt As DataTable = QueryComoDataTable(sql)

        For Each row As DataRow In dt.Rows
            Dim DiaReserva As DateTime = DateTime.Parse(row("data"))
            Dim link As New LinkLabel
            link.Tag = row("id")
            link.Name = $"link{row("id")}"
            link.Text = row("hora") + ("   ") + row("area") + ("   ") + row("mesa")
            link.LinkColor = Color.Red
            listarfldia((DiaReserva.Day - 1) + (IniciarDiaflNumero - 1)).Controls.Add(link)
        Next

    End Sub


    Private Function PegarPrimeiroDiaSemanaAtual() As Integer
        Dim primeirodiames As DateTime = New Date(diaatual.Year, diaatual.Month, 1)
        Return primeirodiames.DayOfWeek + 1
    End Function

    Private Function DiasTotaisDaData() As Integer
        Dim PrimeiroDiaDaDataAtual As DateTime = New Date(diaatual.Year, diaatual.Month, 1)
        Return PrimeiroDiaDaDataAtual.AddMonths(1).AddDays(-1).Day
    End Function

    Private Sub displaydiaatual()

        lbl_meseano.Text = diaatual.ToString("MMMM, yyyy")
        Dim PrimeiroDiaflNumero As Integer = PegarPrimeiroDiaSemanaAtual()
        Dim DiasTotais As Integer = DiasTotaisDaData()

        'lbl_meseano.Text = diaatual.ToString("MMMM, yyyy")
        adicionarlabeldia(PrimeiroDiaflNumero, DiasTotais)
        AdicionarReservaNoDia(PrimeiroDiaflNumero)

    End Sub

    Private Sub mespassado()
        diaatual = diaatual.AddMonths(-1)
        displaydiaatual()
    End Sub

    Private Sub proximomes()
        diaatual = diaatual.AddMonths(1)
        displaydiaatual()
    End Sub

    Private Sub hoje()
        diaatual = DateTime.Today
        displaydiaatual()
    End Sub

    Private Sub gerarpaineldedias(ByVal totaldias As Integer)
        fl_dias.Controls.Clear()
        listarfldia.Clear()

        For i As Integer = 1 To totaldias
            Dim fl As New FlowLayoutPanel
            fl.Name = $"flDia{i}"
            fl.Size = New Size(113, 95)
            fl.BackColor = Color.MistyRose
            fl.BorderStyle = BorderStyle.FixedSingle
            fl.Cursor = Cursors.Hand
            fl.AutoScroll = True
            AddHandler fl.Click, AddressOf Fazer_Reserva
            fl_dias.Controls.Add(fl)
            listarfldia.Add(fl)
        Next
    End Sub

    Private Sub adicionarlabeldia(ByVal diainicioflnumero As Integer, ByVal diasdomes As Integer)

        For Each fl As FlowLayoutPanel In listarfldia
            fl.Controls.Clear()
            fl.Tag = 0
            fl.BackColor = Color.MistyRose
        Next


        For i As Integer = 1 To diasdomes

            Dim lbl As New Label
            lbl.Name = $"lblDia{i}"
            lbl.AutoSize = False
            lbl.TextAlign = ContentAlignment.MiddleLeft
            lbl.Size = New Size(105, 22)
            lbl.Text = i
            lbl.Font = New Font("Bahnschrift SemiCondensed", 10)
            listarfldia((i - 1) + (diainicioflnumero - 1)).Tag = i  'arrumar
            listarfldia((i - 1) + (diainicioflnumero - 1)).Controls.Add(lbl)

            If New Date(diaatual.Year, diaatual.Month, i) = Date.Today Then
                listarfldia((i - 1) + (diainicioflnumero - 1)).BackColor = Color.LightSalmon
            End If
        Next

    End Sub

    Private Sub btn_anterior_Click(sender As Object, e As EventArgs) Handles btn_anterior.Click
        mespassado()
    End Sub

    Private Sub btn_prox_Click(sender As Object, e As EventArgs) Handles btn_prox.Click
        proximomes()
    End Sub

    Private Sub btn_hoje_Click(sender As Object, e As EventArgs) Handles btn_hoje.Click
        hoje()
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

    Private Sub btn_beneficios_Click(sender As Object, e As EventArgs) Handles btn_beneficios.Click
        Beneficios_Reserva.Show()
    End Sub
End Class