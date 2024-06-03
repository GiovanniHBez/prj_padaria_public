Public Class Calendario
    Public id_reserva As Integer = 0

    Private Sub btn_fechar_Click(sender As Object, e As EventArgs) Handles btn_fechar.Click
        Me.Close()

    End Sub

    Private Sub btn_limpar_Click(sender As Object, e As EventArgs) Handles btn_limpar.Click
        'dtp_data.Value = Today
        txt_nome.Clear()
        cmb_area.Text = ""
        cmb_mesa.Text = ""
    End Sub

    Private Sub btn_reservar_Click(sender As Object, e As EventArgs) Handles btn_reservar.Click
        If txt_nome.Text = "" Or
           cmb_area.Text = "" Or
           cmb_mesa.Text = "" Then
            MsgBox("Preencha todos os campos!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        Else 'If id_reserva = 0 Then
            Try
                sql = "select * from tb_booking where data ='" & dtp_data.Value.Date & "' and hora= '" & cmb_hora.Text & "' and area= '" & cmb_area.Text & "' and mesa= '" & cmb_mesa.Text & "'"
                rs = db.Execute(sql)
                If rs.EOF = True Then
                    sql = "insert into tb_booking (data,hora,nome,area,mesa) values ('" & dtp_data.Value & "', " &
                    "'" & cmb_hora.Text & "'," &
                    "'" & txt_nome.Text & "', " &
                    "'" & cmb_area.Text & "', " &
                    "'" & cmb_mesa.Text & "')"
                    rs = db.Execute(sql)
                    MsgBox("Reserva feita com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                    dtp_data.Value = Today
                    txt_nome.Clear()
                    cmb_hora.Text = ""
                    cmb_area.Text = ""
                    cmb_mesa.Text = ""
                Else
                    MsgBox("Mesa indisponível!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
                End If
            Catch ex As Exception
                MsgBox("Verifique se a mesa e a hora desejada estão disponíveis!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Erro ao Reservar")
            End Try
        End If
    End Sub

    Private Sub cmb_mesa_Click(sender As Object, e As EventArgs) Handles cmb_mesa.Click
        If cmb_area.Text = "Interior" Then
            carregar_interno()
        ElseIf cmb_area.Text = "Exterior" Then
            carregar_externo()
        End If
    End Sub

    Private Sub Calendario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar_banco()
        carregar_area()
        carregar_horas()
        If cmb_area.Text = "Interior" Then
            cmb_mesa.Items.Clear()
            carregar_interno()
        ElseIf cmb_area.Text = "Exterior" Then
            cmb_mesa.Items.Clear()
            carregar_externo()
        End If

    End Sub

    Private Sub lkl_vermesas_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkl_vermesas.LinkClicked
        Visualizar_Mesas.Show()
    End Sub

End Class