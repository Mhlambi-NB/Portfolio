Public Class clsDonor

    Private _ID As String
    Private _Name As String
    Private _Contact As String

    Public Property ID As String
        Get
            Return _ID
        End Get
        Set(value As String)
            _ID = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Public Property Contact As String
        Get
            Return _Contact
        End Get
        Set(value As String)
            _Contact = value
        End Set
    End Property

End Class
