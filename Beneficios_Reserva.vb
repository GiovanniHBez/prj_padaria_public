Public Class Beneficios_Reserva
    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Beneficios_Reserva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar_banco()
        carregar_salgados()
        carregar_doces()
    End Sub
End Class