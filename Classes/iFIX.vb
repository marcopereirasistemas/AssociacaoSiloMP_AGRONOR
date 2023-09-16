
Imports FixDataSystems
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Threading

Public Class iFIX

    Enum TipoRetorno
        TipoInteiro = 1
        TipoDouble = 2
        TipoString = 3
    End Enum

    Enum TagTipoEscrita
        Bit = 0
        Inteiro = 1
        Duplo_Float = 2
        Data_Texto = 3
    End Enum

    Protected RotinasDiversas As ClasseRotinasDiversas

    Dim ItemCnt As Integer = 0
    Dim valorLido As Double

    ''' <summary>
    ''' Metodo de leitura de um determinado tag
    ''' </summary>
    ''' <param name="tagGrupo">Grupo de tags no banco de dados do iFIX</param>
    ''' <param name="tagLeitura">TAG a ser lido do supervisorio</param>
    ''' <returns>Retorno é do tipo variant com o valor lido do tag</returns>
    Public Function LerTag(tagGrupo As String, tagLeitura As String, RetornoTipo As TipoRetorno) As Double
        Dim FDSItem As New FixDataSystem

        valorLido = 0

        Try

            FDSItem.Groups.add(tagGrupo)
            FDSItem.Groups(tagGrupo).DataItems.Add(My.Settings.SUPERVISORIO_NODE & "." & tagLeitura.Trim)
            FDSItem.Groups.ITEM(tagGrupo).DataItems.Add(My.Settings.SUPERVISORIO_NODE & "." & tagLeitura.Trim)
            FDSItem.Groups.ITEM(tagGrupo).read()

            If RetornoTipo = TipoRetorno.TipoString Then
                valorLido = FDSItem.Groups.ITEM(tagGrupo).DATAITEMS.ITEM(1).VALUE
                If valorLido <> "" Then
                    valorLido = valorLido.ToString.Trim
                End If
            End If

            If RetornoTipo = TipoRetorno.TipoInteiro Then
                valorLido = Convert.ToInt16(FDSItem.Groups.ITEM(tagGrupo).DATAITEMS.ITEM(1).VALUE)
            End If

            If RetornoTipo = TipoRetorno.TipoDouble Then
                valorLido = FDSItem.Groups.ITEM(tagGrupo).DATAITEMS.ITEM(1).VALUE
            End If

        Catch ex As Exception

            '-- retorna a mensagem de exceção caso ocorra
            MsgBox("LerTag: Erro na leitura do tag: " & tagLeitura & " - Erro: " & ex.Message.ToString)

            valorLido = -1

        End Try

        Return valorLido

    End Function

    Public Sub EscreverNoTag(ByVal strEscreverNoTag As String, ByVal strTagGrupo As String, ByVal ValorEscreverNoTag As Object)
        Dim FdsTemp As New FixDataSystem

        Try
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

            FdsTemp.Groups.Add(strTagGrupo)
            FdsTemp.Groups.item(strTagGrupo).dataitems.add(My.Settings.SUPERVISORIO_NODE & "." & strEscreverNoTag.ToString)
            FdsTemp.Groups.item(strTagGrupo).dataitems.item(1).VALUE = ValorEscreverNoTag
            FdsTemp.Groups.item(strTagGrupo).write()
            FdsTemp.Groups.REMOVE(strTagGrupo)

        Catch ex As Exception

            MsgBox("EscreverNoTag(): Erro: " & ex.Message)

        End Try

    End Sub

    Public Sub SupervisorioEscrever( _
                            ByVal parTagEscrever As String, _
                            ByVal parTagGrupo As String, _
                            ByVal parValorEscreverNoTag As VariantType, _
                            Optional ByVal parEscreverTipo As TagTipoEscrita = TagTipoEscrita.Data_Texto)

        Dim FdsTemp As New FixDataSystem

        Try
            Select Case parEscreverTipo

                Case TagTipoEscrita.Bit

                    parValorEscreverNoTag = Convert.ToSByte(parValorEscreverNoTag)

                Case TagTipoEscrita.Inteiro

                    parValorEscreverNoTag = Convert.ToInt16(parValorEscreverNoTag)

                Case TagTipoEscrita.Duplo_Float ' -- F_CV

                    parValorEscreverNoTag = Convert.ToDouble(Replace(parValorEscreverNoTag, ".", ","))

                Case TagTipoEscrita.Data_Texto ' -- A_DESC ou A_CV

                    parValorEscreverNoTag = CStr(parValorEscreverNoTag)

            End Select

            FdsTemp.Groups.Add(parTagGrupo)
            FdsTemp.Groups.item(parTagGrupo).dataitems.add(My.Settings.SUPERVISORIO_NODE & "." & parTagEscrever.ToString)
            FdsTemp.Groups.item(parTagGrupo).dataitems.item(1).VALUE = parValorEscreverNoTag
            FdsTemp.Groups.item(parTagGrupo).write()
            FdsTemp.Groups.REMOVE(parTagGrupo)

        Catch ex As Exception

            MsgBox("EscreverNoTag(): Erro: " & ex.Message)

        End Try

    End Sub

    Public Sub Escrever(ByVal parTagEscrever As String, _
                        ByVal parTagGrupo As String, _
                        ByVal parValorEscreverNoTag As Object, _
                        ByVal parEscritas As Integer,
                        Optional ByVal parIntervalo As Double = 250,
                        Optional ByVal parEscreverTipo As TagTipoEscrita = TagTipoEscrita.Data_Texto)

        Dim FdsTemp As New FixDataSystem
        Dim Escrita As Integer = 0

        Try

            Select Case parEscreverTipo

                Case TagTipoEscrita.Bit
                    parValorEscreverNoTag = Convert.ToSByte(parValorEscreverNoTag)

                Case TagTipoEscrita.Inteiro
                    parValorEscreverNoTag = Convert.ToInt16(parValorEscreverNoTag)

                Case TagTipoEscrita.Duplo_Float ' -- F_CV
                    parValorEscreverNoTag = Convert.ToDouble(Replace(parValorEscreverNoTag, ".", ","))

                Case TagTipoEscrita.Data_Texto ' -- A_DESC ou A_CV
                    parValorEscreverNoTag = CStr(parValorEscreverNoTag)

            End Select

            While Escrita <= parEscritas

                FdsTemp.Groups.Add(parTagGrupo)
                FdsTemp.Groups.item(parTagGrupo).dataitems.add(My.Settings.SUPERVISORIO_NODE & "." & parTagEscrever.ToString)
                FdsTemp.Groups.item(parTagGrupo).dataitems.item(1).VALUE = parValorEscreverNoTag
                FdsTemp.Groups.item(parTagGrupo).write()
                FdsTemp.Groups.REMOVE(parTagGrupo)

                Thread.Sleep(250)

                Escrita += 1

            End While

        Catch ex As Exception

            MsgBox("EscreverNoTag(): Erro: " & ex.Message)

        End Try


    End Sub






    Public Sub EscreverNoTagFloatDouble(ByVal strEscreverNoTag As String, ByVal strTagGrupo As String, ByVal ValorEscreverNoTag As Double)

        Dim FdsTemp As New FixDataSystem

        Try
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

            FdsTemp.Groups.Add(strTagGrupo)
            FdsTemp.Groups.item(strTagGrupo).dataitems.add(My.Settings.SUPERVISORIO_NODE & "." & strEscreverNoTag.ToString)
            FdsTemp.Groups.item(strTagGrupo).dataitems.item(1).VALUE = ValorEscreverNoTag
            FdsTemp.Groups.item(strTagGrupo).write()
            FdsTemp.Groups.REMOVE(strTagGrupo)

        Catch ex As Exception

            MsgBox("EscreverNoTag(): Erro: " & ex.Message)

        End Try

    End Sub

    Public Sub EscreverNoTagInteiro(ByVal strEscreverNoTag As String, ByVal strTagGrupo As String, ByVal ValorEscreverNoTag As Integer)

        Dim FdsTemp As New FixDataSystem

        Try
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

            FdsTemp.Groups.Add(strTagGrupo)
            FdsTemp.Groups.item(strTagGrupo).dataitems.add(My.Settings.SUPERVISORIO_NODE & "." & strEscreverNoTag.ToString)
            FdsTemp.Groups.item(strTagGrupo).dataitems.item(1).VALUE = ValorEscreverNoTag
            FdsTemp.Groups.item(strTagGrupo).write()
            FdsTemp.Groups.REMOVE(strTagGrupo)

        Catch ex As Exception

            MsgBox("EscreverNoTag(): Erro: " & ex.Message)

        End Try

    End Sub


End Class
