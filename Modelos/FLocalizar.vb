Public Class formLocalizar

    Property strValorRetorno As String

    Protected BancoDados As ClasseBancoDados
    Protected Rotinas As ClasseRotinasDiversas

    Private Sub formLocalizar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BancoDados = New ClasseBancoDados(My.Settings.BANCO_DE_DADOS)

        Rotinas = New ClasseRotinasDiversas

        BancoDados.Abrir()

        strValorRetorno = ""
        txtInformacao.Text = ""
        txtInformacao.Focus()
    End Sub

    Private Sub formLocalizar_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        BancoDados.Fechar()
        BancoDados = Nothing
        Rotinas = Nothing

    End Sub

    Private Sub txtInformacao_Enter(sender As System.Object, e As System.EventArgs) Handles txtInformacao.Enter

        Rotinas.CorEntrada(sender)

    End Sub

    Private Sub txtInformacao_Leave(sender As System.Object, e As System.EventArgs) Handles txtInformacao.Leave

        Rotinas.CorSaida(sender)

    End Sub

    Private Sub txtInformacao_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtInformacao.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then

            e.KeyChar = Microsoft.VisualBasic.Chr(10)

            System.Windows.Forms.SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub btnLocalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnLocalizar.Click

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

    End Sub
End Class