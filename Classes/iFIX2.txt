


Imports System.IO
Imports System.Text
Imports FixDataSystems

Public Class iFIX2

    'Imports FixDataSystems
    'Imports System.IO
    'Imports System.Text
    'Imports System.Data.SqlClient
'
        Enum TipoRetorno
            TipoInteiro = 1
            TipoDouble = 2
            TipoString = 3
        End Enum


        Dim ItemCnt As Integer = 0
        Dim valorLido As Double

    Public Function LerTag(ByRef oIFIX_Escrita As FixDataSystem, _
                           tagGrupo As String, _
                           tagLeitura As String, _
                           RetornoTipo As TipoRetorno, _
                           ByRef clRotinas As ClasseRotinasDiversas) As Double

        Try

            '-- adiciona o tag grupo aos grupos do iFIX
            '-- adiciona o tag ao taggroup no dataitens
            '-- adiciona o item ao grupo de itens
            '-- realiza a leitura do tag
            oIFIX_Escrita.Groups.add(tagGrupo)
            oIFIX_Escrita.Groups(tagGrupo).DataItems.Add(My.Settings.SUPERVISORIO_NODE & "." & tagLeitura.Trim)
            oIFIX_Escrita.Groups.ITEM(tagGrupo).DataItems.Add(My.Settings.SUPERVISORIO_NODE & "." & tagLeitura.Trim)
            oIFIX_Escrita.Groups.ITEM(tagGrupo).read()

            '-- retorna o valor lido do tag
            If RetornoTipo = TipoRetorno.TipoString Then

                valorLido = (oIFIX_Escrita.Groups.ITEM(tagGrupo).DATAITEMS.ITEM(1).VALUE).ToString

                If valorLido <> "" Then

                    valorLido = valorLido.ToString.Trim

                End If

            End If

            If RetornoTipo = TipoRetorno.TipoInteiro Then

                valorLido = Convert.ToInt16(oIFIX_Escrita.Groups.ITEM(tagGrupo).DATAITEMS.ITEM(1).VALUE)

            End If

            If RetornoTipo = TipoRetorno.TipoDouble Then

                valorLido = oIFIX_Escrita.Groups.ITEM(tagGrupo).DATAITEMS.ITEM(1).VALUE

            End If

        Catch ex As Exception

            '-- retorna a mensagem de exceção caso ocorra
            clRotinas.EscreverEmLog("LerTag(): Erro: " & ex.Message, ClasseRotinasDiversas.Tipo.Geral)
            MsgBox("LerTag: Erro na leitura do tag: " & tagLeitura & " - Erro: " & ex.Message.ToString)

            '-- retorno o valor -1
            valorLido = -1

        End Try

        Return valorLido

    End Function

    Public Sub EscreverNoTag(ByRef oIFIX_Leitura As FixDataSystem, _
                             ByVal strEscreverNoTag As String, _
                             ByVal strTagGrupo As String, _
                             ByVal ValorEscreverNoTag As Object, _
                             ByRef clRotinas As ClasseRotinasDiversas)

        Try
            clRotinas.EscreverEmLog("EscreverNoTag(): TAG: " & strEscreverNoTag.ToString & " - VALOR: " & ValorEscreverNoTag.ToString, ClasseRotinasDiversas.Tipo.Simples)

            '-- A_DESC
            If strEscreverNoTag.Substring(strEscreverNoTag.Length - 6, 6) = "A_DESC" Then
                ValorEscreverNoTag = CStr(ValorEscreverNoTag)
            End If

            '-- A_CV
            If strEscreverNoTag.Substring(strEscreverNoTag.Length - 4, 4) = "A_CV" Then
                ValorEscreverNoTag = CStr(ValorEscreverNoTag)
            End If

            '-- <> A_DESC 
            '-- <> A_CV
            If strEscreverNoTag.Substring(strEscreverNoTag.Length - 6, 6) <> "A_DESC" And strEscreverNoTag.Substring(strEscreverNoTag.Length - 6, 6) = "A_CV" Then
                ValorEscreverNoTag = Convert.ToDouble(Replace(ValorEscreverNoTag, ".", ","))
            End If

            oIFIX_Leitura.Groups.Add(strTagGrupo)
            oIFIX_Leitura.Groups.item(strTagGrupo).dataitems.add(My.Settings.SUPERVISORIO_NODE & "." & strEscreverNoTag.ToString)
            oIFIX_Leitura.Groups.item(strTagGrupo).dataitems.item(1).VALUE = ValorEscreverNoTag
            oIFIX_Leitura.Groups.item(strTagGrupo).write()
            oIFIX_Leitura.Groups.REMOVE(strTagGrupo)

        Catch ex As Exception

            '-- retorna mensagem de exceção caso ocorra
            clRotinas.EscreverEmLog("EscreverNoTag(): Erro: " & ex.Message, ClasseRotinasDiversas.Tipo.Simples)
            MsgBox("EscreverNoTag(): Erro: " & ex.Message)

        End Try

    End Sub

End Class
