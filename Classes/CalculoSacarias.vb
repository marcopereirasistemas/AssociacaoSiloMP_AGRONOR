

Public Class CalculoSacarias

    Private _resto As Double
    Private _qtdeTotalEnsacados As Double
    Private _numeroSacos As Double
    Private _diferenca As Double

    Private _qtdeDesejada As Double
    Private _tamanhoSaco As Double

    Public Sub New()
    End Sub

    Public Sub New(ByVal xqtdedesejada As Double, ByVal xtamanhosaco As Double)

        _qtdeDesejada = xqtdedesejada
        _tamanhoSaco = xtamanhosaco

    End Sub

    Public Property QtdeDesejada() As Double
        Get
            Return _qtdeDesejada
        End Get
        Set(ByVal value As Double)
            _qtdeDesejada = value
        End Set
    End Property

    Public Property TamanhoSaco() As Double
        Get
            Return _tamanhoSaco
        End Get
        Set(ByVal value As Double)
            _tamanhoSaco = value
        End Set
    End Property

    Public Sub Calcular()

        _resto = _qtdeDesejada Mod _tamanhoSaco

        _qtdeTotalEnsacados = _qtdeDesejada - _resto

        _numeroSacos = _qtdeTotalEnsacados / _tamanhoSaco

        _diferenca = _resto

    End Sub

    Public ReadOnly Property Resto() As Double
        Get
            Return _resto
        End Get
    End Property

    Public ReadOnly Property QuantidadeTotalEnsacados
        Get
            Return _qtdeTotalEnsacados
        End Get
    End Property

    Public ReadOnly Property NumeroSacos
        Get
            Return _numeroSacos
        End Get
    End Property

    Public ReadOnly Property Diferenca
        Get
            Return _diferenca
        End Get
    End Property

End Class
