'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Componente
    Public Property IDCom As Integer
    Public Property NomCom As String
    Public Property FKIDUniMed As Nullable(Of Integer)

    Public Overridable Property AlimentoComponente As ICollection(Of AlimentoComponente) = New HashSet(Of AlimentoComponente)
    Public Overridable Property UnidadMedida As UnidadMedida

End Class
